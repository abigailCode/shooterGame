using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusGameManager : MonoBehaviour
{

    [SerializeField]  GameObject GameOverPanel;
    [SerializeField]  GameObject GameWonPanel;

    private void OnEnable()
    {
        InitGame.OnGameInit += StartTimer;
        InitGame.OnGameInit += StartMovement;
        InitGame.OnGameInit += PlayMainTheme;
        InitGame.OnGameInit += AnimateTitle;
    }

    private void OnDisable()
    {
        InitGame.OnGameInit -= StartTimer;
        InitGame.OnGameInit -= StartMovement;
        InitGame.OnGameInit -= PlayMainTheme;
        InitGame.OnGameInit -= AnimateTitle;
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


    void GameOver()
    {
        PauseGame();
        GameOverPanel.SetActive(true);
    }

    void GameWon()
    {
        PauseGame();
        GameWonPanel.SetActive(true);
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
    } 
}
