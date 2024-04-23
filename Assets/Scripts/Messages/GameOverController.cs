using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{

    [SerializeField] string message = "";
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            GetComponent<PlaySFX>().PlaySFXClip();
            GameObject.Find("Main Camera").SendMessage(message);
        }
    }
}
