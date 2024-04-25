using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusGameManager : MonoBehaviour
{

    [SerializeField]  GameObject GameOverPanel;
    [SerializeField]  GameObject GameWonPanel;
    [SerializeField]  GameObject Pointer;
    [SerializeField]  GameObject target;
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

    void CaptureScreenshot()
    {
        string screenshotName = "screenshot.png";
        ScreenCapture.CaptureScreenshot(screenshotName);
        StartCoroutine(LoadScreenshot(screenshotName));
    }

    IEnumerator LoadScreenshot(string path)
    {
        yield return new WaitForSecondsRealtime(0.2f); 
        Texture2D texture = new Texture2D(Screen.width, Screen.height);
        texture.LoadImage(System.IO.File.ReadAllBytes(path));
        screenshotImage.texture = texture;
    }
}
