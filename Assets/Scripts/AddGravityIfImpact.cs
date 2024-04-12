using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGravityIfImpact : MonoBehaviour {
    [SerializeField] int timeToDestroy = 5;

    // Si el proyectil impacta con algo le añadimos la gravedad
    private void OnCollisionEnter(Collision collision) {
        // Si existe colisión se añade gravedad
        if (collision != null) {
            GetComponent<Rigidbody>().useGravity = true;
        }
    }

    // ------------------------------------------------------
    // Corrutina que duerme el objeto despues de N segundos
    // ------------------------------------------------------
    IEnumerator DisableAfterNSeconds(int secondsToDisable)
    {
        // Esperamos los segundos especificados
        yield return new WaitForSeconds(secondsToDisable);
        // Dormimos el objeto
        this.gameObject.SetActive(false);
    }


    // ------------------------------------------------------
    // Método que se ejecuta cuando el objeto despierta
    // ------------------------------------------------------
    private void OnEnable()
    {
        // En vez de destruir... dormirmos el objeto del pool
        StartCoroutine(DisableAfterNSeconds(timeToDestroy));
    }

}
