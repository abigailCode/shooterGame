using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveJumpMessage : MonoBehaviour
{
    [SerializeField] float jumpForce = 10;
    private void Jump()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
