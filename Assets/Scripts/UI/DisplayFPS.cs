using TMPro;
using UnityEngine;

public class DisplayFPS : MonoBehaviour {
    [SerializeField] TextMeshProUGUI _fpsText;
    float _deltaTime = 0.0f;

    void Update() {
        _deltaTime += (Time.unscaledDeltaTime - _deltaTime) * 0.1f;
        float fps = 1.0f / _deltaTime;
        _fpsText.text = $"FPS: {Mathf.Round(fps)}";
    }
}
