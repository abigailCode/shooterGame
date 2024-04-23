using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RockController : MonoBehaviour
{
    private void Start()
    {
        // Llamamos a la corrutina que desactiva el objeto despues de N segundos
        GetComponent<PlaySFX>().PlaySFXClip();
        StartCoroutine(DisableAfterNSeconds(2));
    }

    public IEnumerator DisableAfterNSeconds(int secondsToDisable)
    {
        yield return new WaitForSeconds(secondsToDisable);
        Destroy(this.gameObject);
    }
}
