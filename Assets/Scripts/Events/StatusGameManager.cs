using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class StatusGameManager : MonoBehaviour
{

    [SerializeField]  GameObject GameOverPanel;
    [SerializeField]  GameObject GameWonPanel;
    [SerializeField]  GameObject Pointer;
  
    public RawImage screenshotImage;

    private void OnEnable()
    {
        InitGame.OnGameInit += StartTimer;
        InitGame.OnGameInit += StartMovement;
        InitGame.OnGameInit += PlayMainTheme;
        InitGame.OnGameInit += AnimateTitle;
        InitGame.OnGameInit += ActivatePointer;
    }

    private void OnDisable()
    {
        InitGame.OnGameInit -= StartTimer;
        InitGame.OnGameInit -= StartMovement;
        InitGame.OnGameInit -= PlayMainTheme;
        InitGame.OnGameInit -= AnimateTitle;
        InitGame.OnGameInit -= ActivatePointer;
    }

    private void Start()
    {
        AudioManager.instance.PlayMusic("menu");
    }

    private void StartTimer()
    {
        GameObject.Find("HUD").GetComponent<Timer>().enabled = true;
    }

    void StartMovement()
    {
        GameObject.Find("Player").GetComponent<CharacterController>().enabled = true;
    }

    void PlayMainTheme()
    {
        AudioManager.instance.PlayMusic("main");
      
    }

    void AnimateTitle()
    {
        GameObject.Find("Title").GetComponent<Animator>().SetBool("disappear", true);
    }

    void ActivatePointer()
    {
        Pointer.SetActive(true);
    }

    void GameOver()
    {
        PauseGame();
        screenshotImage = GameOverPanel.transform.GetChild(0).gameObject.transform.Find("Screenshot").GetComponent<RawImage>();
        CaptureScreenshot();
        StartCoroutine(ShowPanel(GameOverPanel));
    }

    IEnumerator ShowPanel(GameObject panel)
    {
        yield return new WaitForSecondsRealtime(0.2f);
        panel.SetActive(true);
    }

    void GameWon()
    {
        PauseGame();
        screenshotImage = GameWonPanel.transform.GetChild(0).gameObject.transform.Find("Screenshot").GetComponent<RawImage>();
        CaptureScreenshot();
        StartCoroutine(ShowPanel(GameWonPanel));
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
    }

    //void CaptureScreenshot()
    //{
    //    string screenshotName = "screenshot.png";
    //    string screenshotPath = Path.Combine(Application.persistentDataPath, "Screenshots");
    //    if (!Directory.Exists(screenshotPath)) Directory.CreateDirectory(screenshotPath);
    //    screenshotPath = Path.Combine(screenshotPath, screenshotName);
    //    Debug.Log(screenshotPath);
    //    ScreenCapture.CaptureScreenshot(screenshotPath);
    //    StartCoroutine(LoadScreenshot(screenshotPath));
    //}

    //IEnumerator LoadScreenshot(string path)
    //{
    //    yield return new WaitForSecondsRealtime(0.2f);
    //    byte[] fileData = System.IO.File.ReadAllBytes(path);
    //    Texture2D texture = new Texture2D(Screen.width, Screen.height);
    //    texture.LoadImage(fileData);
    //    screenshotImage.texture = texture;
    //}

    void CaptureScreenshot()
    {
        StartCoroutine(LoadScreenshot());
    }

    IEnumerator LoadScreenshot()
    {
        // Espera un frame para que la captura de pantalla se complete
        yield return new WaitForEndOfFrame();

        // Crea una nueva textura con las dimensiones de la pantalla
        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

        // Lee los datos de la pantalla en la textura
        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        texture.Apply();

        // Aplica la textura a la imagen del canvas
        screenshotImage.texture = texture;
    }


}
