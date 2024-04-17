using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayFPS : MonoBehaviour
{
    // Referencia al TextMeshPro con el texto
    public TextMeshProUGUI fpsText;
    // Variable privada para acumular el tiempo
    private float deltaTime = 0.0f;
    private void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = $"FPS: {Mathf.Round(fps)}";
    }
}
