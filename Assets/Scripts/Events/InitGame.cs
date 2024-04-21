using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitGame : MonoBehaviour
{
    public delegate void InitGameDelegate();

    public static event InitGameDelegate OnGameInit;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            if (OnGameInit != null)
            {
                OnGameInit();
                OnGameInit = null;
            }
        }
    }
}
