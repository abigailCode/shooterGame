using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour {
    [SerializeField] float _remainingTime = 160f;
    bool _timerRunning = true;
    TMP_Text _timerText;

    void Start() {
        _timerText = GetComponent<TMP_Text>();
        SetTimerText();
    }

    void Update() {
        if (_timerRunning) {
            _remainingTime -= Time.deltaTime;

            if (_remainingTime <= 0) {
                _remainingTime = 0;
                _timerRunning = false;
                _timerText.GetComponent<PlaySFX>().PlaySFXClip();
                GameObject.Find("Main Camera").SendMessage("GameOver");   
            }
            SetTimerText();
        }
    }

    void SetTimerText() {
        string minutes = (Mathf.Floor(Mathf.Round(_remainingTime) / 60)).ToString();
        string seconds = (Mathf.Round(_remainingTime) % 60).ToString();

        if (minutes.Length == 1) { minutes = "0" + minutes; }
        if (seconds.Length == 1) { seconds = "0" + seconds; }

        _timerText.text = minutes + ":" + seconds;
    }
    
}
