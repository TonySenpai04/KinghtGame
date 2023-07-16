using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnCickBtn : MonoBehaviour
{
    public AudioSource audioSource;
    public void OnButtonClick()
    {
        audioSource.PlayOneShot(AudioPlayer.instance.ClickBtnSound); 
    }

}
