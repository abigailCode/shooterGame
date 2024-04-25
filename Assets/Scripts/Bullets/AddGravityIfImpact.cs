using System.Collections;
using UnityEngine;

public class AddGravityIfImpact : MonoBehaviour {
    [SerializeField] float _secondsToDisable = 5;
    Rigidbody _rigidbody;

    void Start() { _rigidbody = GetComponent<Rigidbody>(); }
    
    void OnCollisionEnter(Collision collision) {
        if (collision != null) _rigidbody.useGravity = true;
    }

    IEnumerator DisableAfterNSeconds() {
        yield return new WaitForSeconds(_secondsToDisable);
        _rigidbody.useGravity = false;
        gameObject.SetActive(false);
    }

    void OnEnable() { StartCoroutine(DisableAfterNSeconds()); }

}
