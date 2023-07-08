using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ActionbarUi : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IEndDragHandler, IDropHandler, IDragHandler

{
        public Image Image;
        public SkillS0 Skill;
        public event Action<ActionbarUi> OnItemDropOn, OnItemBeginDrap, OnItemEndDrap, OnRightMouseBtnClick, OnItemClicked;
        public bool empty = true;
        private void Start()
        {
          SetData();
        }
        
        public void SetData()
        {
          Image.sprite = Skill.Icon;
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

