using UnityEngine;

public class StatusGameManager : MonoBehaviour {
    [SerializeField] GameObject _gameOverPanel, _gameWonPanel;
    GameObject _player;

    void OnEnable() {
        InitGame.OnGameInit += StartTimer;
        InitGame.OnGameInit += StartMovement;
    }

    void OnDisable() {
        InitGame.OnGameInit -= StartTimer;
        InitGame.OnGameInit -= StartMovement;
    }

    void Start() { _player = GameObject.Find("Player"); }

    void StartTimer() { GameObject.Find("Timer").GetComponent<Timer>().enabled = true; }

    void StartMovement() { _player.GetComponent<CharacterController>().enabled = true; }

    void OnGameOver() { PauseGame(); _gameOverPanel.SetActive(true); }

    void OnGameWon() { PauseGame(); _gameWonPanel.SetActive(true); }

    void PauseGame() {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        _player.GetComponent<PlayerController>().enabled = false;
        _player.GetComponent<FPController.FPController>().enabled = false;
    }
}
