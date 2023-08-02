using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NpcClick : MonoBehaviour, IPointerClickHandler
{
    public static NpcClick Instance;
    public GameObject GiftCode;
    public GameObject PannelSkill;
    public  bool IsSkill=true;

    private void Start()
    {
        Instance = this;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        GiftCode.SetActive(true);
        PannelSkill.SetActive(false);
        IsSkill = false;
  
    }
    public void Close()
    {
        this.GiftCode.SetActive(false);
        this. PannelSkill.SetActive(true );
        IsSkill = true;
    }
}
