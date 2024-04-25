using System.Collections;
using UnityEngine;

public class ExplosionController : MonoBehaviour {
    private void Start() {
        GetComponent<PlaySFX>().PlaySFXClip();
        StartCoroutine(DestroyAfterNSeconds(2));
    }

    public IEnumerator DestroyAfterNSeconds(int secondsToDestroy) {
        yield return new WaitForSeconds(secondsToDestroy);
        Destroy(gameObject);
    }
}
