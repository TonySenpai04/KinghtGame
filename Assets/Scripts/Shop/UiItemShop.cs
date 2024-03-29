﻿using Inventory;
using Inventory.Model;
using Inventory.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Inventory.UI
{
    public class UiItemShop : UiItem, IPointerClickHandler, IBeginDragHandler, IEndDragHandler, IDropHandler, IDragHandler
    {
        public static UiItemShop Instance;
        public event Action<UiItemShop> OnItemDropOn, OnItemBeginDrap, OnItemEndDrap, OnRightMouseBtnClick, OnItemClicked;
        [SerializeField] public ItemActionPanel transformPannelAction;
        [SerializeField] protected TextMeshProUGUI Description;
        public float Price;
        [SerializeField] public ItemSO item;
        public InventoryItem inventoryItem;
        private void Awake()
        {
            Instance = this;

        }
        private void Start()
        {
            
            if (item.type.ToString() == "Gold")
            {
                SetData(item.ItemImage, item.BackGround, "<color=green>"+item.Name+ "</color>" + "\n" + item.Description + "\nPrice:" + item.Price.ToString("#,##").Replace(',', '.')+"G");
            }
            else
            {
                SetData(item.ItemImage, item.BackGround, "<color=green>" +item.Name + "</color>" + "\n" + item.Description + "\nPrice:" + item.Price.ToString("#,##").Replace(',', '.') + "D");
            }
            Deselect();
        }
        internal virtual
            InventoryItem GetItemAt()
        {
            return UsingItemController.Instance.inventoryData.inventoryItems[index];
        }
        public void ResetData()
        {
            this.borderImage.gameObject.SetActive(false);
            empty = true;

        }
        public virtual void Select()
        {
            borderImage.enabled = true;
            transform.gameObject.SetActive(true);
            transformPannelAction.Toggle(true);
            transformPannelAction.transform.SetParent(transform);
            transformPannelAction.transform.position = transform.position + new Vector3(1.6f, 0, 0);
            ActionItemShop.Instance.AddAction();
        }
        public void Deselect()
        {
            borderImage.enabled = false;
        }
        public void SetData(Sprite sprite, Sprite background, string description)
        {

            this.BackGround.gameObject.SetActive(true);
            this.Price = item.Price;
            this.Image.sprite = sprite;
            this.Description.text = description;
            transformPannelAction = ShopItemPage.Instance.actionPanel;
            this.BackGround.sprite = background;
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
}

