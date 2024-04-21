using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySFX : MonoBehaviour
{
    [SerializeField] string sfxName;
    string sfxPath = "SFX/";

    public void PlaySFXClip()
    {
        AudioClip sfxClip = Resources.Load<AudioClip>(sfxPath + sfxName);
        StartCoroutine(PlaySFXCoroutine(sfxClip));
    }

    IEnumerator PlaySFXCoroutine(AudioClip sfxClip)
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = sfxClip;
        audioSource.Play();
        yield return new WaitForSeconds(sfxClip.length);
        Destroy(audioSource);
    }
}
