using UnityEngine;

public class SendJumpMessage : MonoBehaviour {
    public void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Projectile") GameObject.Find("Target").SendMessage("Jump");
    }
}
