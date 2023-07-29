using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NpcClick : MonoBehaviour, IPointerClickHandler
{
    public GameObject GiftCode;

    public void OnPointerClick(PointerEventData eventData)
    {
        GiftCode.SetActive(true);
    }
}
