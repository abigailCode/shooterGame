using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour {
    public float remainingTime = 160f;
    private bool timerRunning = true;
    private TMP_Text timer;

    private void Awake()
    {
        timer = GameObject.Find("Timer").GetComponent<TMP_Text>();
        SetTimer();

    }
    void Update() {
        if (timerRunning) {
            remainingTime -= Time.deltaTime; // Decrement remaining time by deltaTime

            if (remainingTime <= 0) {
                remainingTime = 0; // Ensure timer doesn't go negative
                timerRunning = false; // Stop timer when it reaches 0
                timer.GetComponent<PlaySFX>().PlaySFXClip();
                GameObject.Find("Main Camera").SendMessage("GameOver");   
            }

           SetTimer();
        }
    }

    public void SetTimer()
    {
        string minutes = (Mathf.Floor(Mathf.Round(remainingTime) / 60)).ToString();
        string seconds = (Mathf.Round(remainingTime) % 60).ToString();

        if (minutes.Length == 1) { minutes = "0" + minutes; }
        if (seconds.Length == 1) { seconds = "0" + seconds; }

        timer.text = minutes + ":" + seconds;
    }
   
    

}
