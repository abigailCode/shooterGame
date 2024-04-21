using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameManager : MonoBehaviour
{
    private void OnEnable()
    {
        InitGame.OnGameInit += StartTimer;
        InitGame.OnGameInit += StartMovement;
        InitGame.OnGameInit += PlayMainTheme;
    }

    private void OnDisable()
    {
        InitGame.OnGameInit -= StartTimer;
        InitGame.OnGameInit -= StartMovement;
        InitGame.OnGameInit -= PlayMainTheme;
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

}
