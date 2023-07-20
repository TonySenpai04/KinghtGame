using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnCickBtn : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip ClickClip;
    public void OnButtonClick()
    {
        if (ClickClip == null)
        {
            audioSource.PlayOneShot(AudioPlayer.instance.ClickBtnSound);
        }
        else
        {
            audioSource.PlayOneShot(ClickClip);
        }
    }

}
