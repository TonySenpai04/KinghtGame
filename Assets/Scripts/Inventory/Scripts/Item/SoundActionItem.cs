using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SoundActionItem : MonoBehaviour,IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {

        AudioSource.PlayClipAtPoint(AudioPlayer.instance.ActionSound,transform.position,1);   
    }

    
}
