using UnityEngine;

public class ReceiveJumpMessage : MonoBehaviour {
    [SerializeField] float _jumpForce = 10;
    Rigidbody _rigidbody;

    void Start() {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Jump() {
        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }
}
