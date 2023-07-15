using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnCickBtn : MonoBehaviour
{
    public AudioClip clickSound;
    public AudioSource clickSoundSource;
    public void OnButtonClick()
    {
        Debug.Log(clickSoundSource.enabled);
        clickSoundSource.enabled = true;
        clickSoundSource.Play();
        StartCoroutine(PlayClickSound());
    }

    private IEnumerator PlayClickSound()
    {
        clickSoundSource.PlayOneShot(clickSound);
        yield return new WaitForSeconds(clickSound.length);
        clickSoundSource.enabled = true;
    }
}
