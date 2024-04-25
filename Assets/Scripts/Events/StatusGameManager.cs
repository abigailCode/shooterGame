using UnityEngine;

public class StatusGameManager : MonoBehaviour {
    [SerializeField] GameObject _gameOverPanel, _gameWonPanel;

    void OnEnable() {
        InitGame.OnGameInit += StartTimer;
        InitGame.OnGameInit += StartMovement;
    }

    void OnDisable() {
        InitGame.OnGameInit -= StartTimer;
        InitGame.OnGameInit -= StartMovement;
    }

    void StartTimer() {
        GameObject.Find("HUD").GetComponent<Timer>().enabled = true;
    }

    void StartMovement() {
        GameObject.Find("Player").GetComponent<CharacterController>().enabled = true;
    }

    void OnGameOver() { PauseGame(); _gameOverPanel.SetActive(true); }

    void OnGameWon() { PauseGame(); _gameWonPanel.SetActive(true); }

    void PauseGame() {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
    }
}
