using UnityEngine;

public class GameOverController : MonoBehaviour {
    [SerializeField] string _message = "";

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Target") {
            GetComponent<PlaySFX>().PlaySFXClip();
            GameObject.Find("Main Camera").SendMessage(_message);
        }
    }
}
