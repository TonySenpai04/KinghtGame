using Inventory.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Inventory.UI
{
    public class InventoryItemUsing : UiItem, IPointerClickHandler, IBeginDragHandler, IEndDragHandler, IDropHandler, IDragHandler
    {
        public static InventoryItemUsing Instance;
        public event Action<InventoryItemUsing> OnItemDropOn, OnItemBeginDrap, OnItemEndDrap, OnRightMouseBtnClick, OnItemClicked;
        [SerializeField] protected TextMeshProUGUI quantitytext;
        [SerializeField] public GameObject buttonPrefab;
        [SerializeField]
        public ItemActionPanel panelConfirm;
        public InventoryItem inventoryItem;
        private void Awake()
        {
            Instance = this;
            ResetData();
            Deselect();

        }
        private void Start()
        {
            Transformbtn = InventoryPage.Instance.actionPanel;
            panelConfirm = InventoryPage.Instance.panel;
        }
        internal virtual
            InventoryItem GetItemAt()
        {
            return UsingItemController.Instance.inventoryData.inventoryItems[index];
        }
        public void ResetData()
        {
            this.BackGround.gameObject.SetActive(false);
            this.quantitytext.text = "";
            empty = true;

        }
        public virtual void Select()
        {
            borderImage.enabled = true;
            transform.gameObject.SetActive(true);
            InventoryPageUsingItem.Instance.actionPanel.Toggle(true);
            InventoryPageUsingItem.Instance.actionPanel.transform.SetParent(transform);
            InventoryPageUsingItem.Instance.actionPanel.transform.position = transform.position;
            ItemActionUsing.Instance.AddAction();
        }
        public void Deselect()
        {
            borderImage.enabled = false;
        }
        public void SetData(Sprite sprite, int quatity, Sprite background)
        {

            this.BackGround.gameObject.SetActive(true);
            this.Image.sprite = sprite;
            this.BackGround.sprite = background;
            if (quatity <= 1)
            {
                this.quantitytext.text = "";
            }
            else
            {
                this.quantitytext.text = quatity.ToString();
            }
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
