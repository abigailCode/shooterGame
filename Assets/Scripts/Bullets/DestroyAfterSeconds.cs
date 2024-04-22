using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour {

    // Tiempo de vida del objeto
    [SerializeField] int timeToDestroy = 5;

    // ------------------------------------------------------
    // Corrutina que duerme el objeto despues de N segundos
    // ------------------------------------------------------
    public IEnumerator DisableAfterNSeconds(int secondsToDisable)
    {
        // Esperamos los segundos especificados
        yield return new WaitForSeconds(secondsToDisable);
        // Dormimos el objeto
        this.gameObject.SetActive(false);
    }

    // ------------------------------------------------------
    // Método que se ejecuta cuando el objeto despierta (AddGravityIfImpact)
    // ------------------------------------------------------
    // Si el proyectil vuelve a mostrarse le quitamos la gravedad
    private void OnEnable()
    {
        GetComponent<Rigidbody>().useGravity = false;
    }



}
