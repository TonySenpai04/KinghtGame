using Inventory.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DescriptionSkillUI : MonoBehaviour,IPointerClickHandler, IBeginDragHandler, IEndDragHandler, IDropHandler, IDragHandler
{
    public static DescriptionSkillUI Instance;
    public SkillS0 SkillPlayer;
    public Image ICon;
    public TextMeshProUGUI TxtDescription;
    public float CooldownTime;
    public int Level;
    public int LevelSkill;
    public int ManaConsumption;
    public float DmgAdd;
    public event Action<DescriptionSkillUI> OnItemDropOn, OnItemBeginDrap, OnItemEndDrap, OnRightMouseBtnClick, OnItemClicked;
    [SerializeField] protected bool empty = false;
    [SerializeField] public int index;
    [SerializeField] public ItemActionPanel transformPannelAction;
    [SerializeField] public Image borderImage;
   
    private void Start()
    {
        Instance = this;
        Deselect();
        transformPannelAction = SkillPage.Instance.actionPanel;
      

    }
    public void ResetData()
    {
        this.borderImage.gameObject.SetActive(false);
        empty = false;
        

    }
    public virtual void Select()
    {
        if (LevelSystem.Instance.level > SkillPlayer.RequiredLevel)
        {
            borderImage.enabled = true;
            transformPannelAction.Toggle(true);
            transformPannelAction.transform.SetParent(transform);
            transformPannelAction.transform.position = transform.position + new Vector3(4f, 0, 0);
            UpgradeSkill.Instance.AddAction();
        }
    }
    public void SetDescription(SkillS0 skill)
    {
        ICon.sprite = skill.Icon;
        DmgAdd = skill.DmgAdd;
        CooldownTime = skill.CooldownTime;
        Level= skill.RequiredLevel;
        LevelSkill = skill.LevelSkill;
        ManaConsumption= skill.ManaConsumption;
        TxtDescription.text = " Inflict damage " +DmgAdd*100+"%"+ "\n Required level: " +
        Level + "\n Level: "+ LevelSkill+ "\n Mana Consumption: "+ ManaConsumption + "\n Cooldown Time: " + CooldownTime;
    }

    public void Deselect()
    {
        borderImage.enabled = false;
    }
    public void OnPointerClick(PointerEventData pointerdata)
    {
        if (empty)
            return;
        if (pointerdata.button == PointerEventData.InputButton.Right)
        {
            OnRightMouseBtnClick?.Invoke(this);
        }
        else
        {
            OnItemClicked?.Invoke(this);
        }
  
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (empty)
            return;
        OnItemBeginDrap?.Invoke(this);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnItemEndDrap?.Invoke(this);
    }

    public void OnDrop(PointerEventData eventData)
    {
        OnItemDropOn?.Invoke(this);
    }

    public void OnDrag(PointerEventData eventData)
    {

    }
}

