using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusGameManager : MonoBehaviour
{

    [SerializeField] GameObject GameOverPanel, GameWonPanel;
    public RawImage screenshotImage;

    private void OnEnable()
    {
        InitGame.OnGameInit += StartTimer;
        InitGame.OnGameInit += StartMovement;
        InitGame.OnGameInit += AnimateTitle;
    }

    private void OnDisable()
    {
        InitGame.OnGameInit -= StartTimer;
        InitGame.OnGameInit -= StartMovement;
        InitGame.OnGameInit -= AnimateTitle;
    }

    private void StartTimer()
    {
        GameObject.Find("HUD").GetComponent<Timer>().enabled = true;
    }

    void StartMovement()
    {
        GameObject.Find("Player").GetComponent<CharacterController>().enabled = true;
    }

    void AnimateTitle()
    {
        GameObject.Find("Title").GetComponent<Animator>().SetBool("disappear", true);
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
