using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ActionbarUi : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IEndDragHandler, IDropHandler, IDragHandler
{
        [SerializeField] public Image Image;
        public event Action<ActionbarUi> OnItemDropOn, OnItemBeginDrap, OnItemEndDrap, OnRightMouseBtnClick, OnItemClicked;
        public bool empty = true;
        private void Awake()
        {
           // ResetData();
            Deselect();

        }
        public void ResetData()
        {

            this.Image.gameObject.SetActive(false);

            empty = true;
        }
        public void Select()
        {
        this.Image.enabled = true;

        }
        public void Deselect()
        {
        this.Image.enabled = false;

         }
        public void SetData(Sprite sprite)
        {

            this.Image.gameObject.SetActive(true);
            this.Image.sprite = sprite;
            empty = false;
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
        AnimationPlayer.instance.Skill1();
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
