using System.Collections;
using UnityEngine;

public class PlaySFX : MonoBehaviour {
    [SerializeField] AudioClip _audioClip;

    public void PlaySFXClip() { StartCoroutine(PlaySFXCoroutine()); }

    IEnumerator PlaySFXCoroutine() {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = _audioClip;
        audioSource.Play();
        yield return new WaitForSeconds(_audioClip.length);
        Destroy(audioSource);
    }
}
