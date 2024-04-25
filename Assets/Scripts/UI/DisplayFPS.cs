using TMPro;
using UnityEngine;

public class DisplayFPS : MonoBehaviour {
    TextMeshProUGUI _fpsText;
    float _deltaTime = 0.0f;

    void Start () {  _fpsText = GetComponent<TextMeshProUGUI>(); }

    void Update() {
        _deltaTime += (Time.unscaledDeltaTime - _deltaTime) * 0.1f;
        float fps = 1.0f / _deltaTime;
        _fpsText.text = $"FPS: {Mathf.Round(fps)}";
    }
}
