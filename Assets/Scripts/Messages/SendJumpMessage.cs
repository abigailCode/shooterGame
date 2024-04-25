using UnityEngine;

public class SendJumpMessage : MonoBehaviour {
    public void SendJump() {
        GameObject.Find("Target").SendMessage("Jump");
    }
}
