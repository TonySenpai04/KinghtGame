using Inventory;
using Inventory.Model;
using Inventory.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Inventory.UI
{
    public class UiItemShop : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IEndDragHandler, IDropHandler, IDragHandler
    {
        public static UiItemShop Instance;
        public event Action<UiItemShop> OnItemDropOn, OnItemBeginDrap, OnItemEndDrap, OnRightMouseBtnClick, OnItemClicked;
        [SerializeField] protected Image Image;
        [SerializeField] public Image borderImage;
        //   [SerializeField] public GameObject buttonPrefab;
         [SerializeField] public ItemActionPanel Transformbtn;
        [SerializeField] protected bool empty = true;
        [SerializeField] public int index;
        // [SerializeField]
        // public ItemActionPanel panelConfirm;
        [SerializeField] protected Image BackGround;
        [SerializeField]
        protected TextMeshProUGUI Description;

        [SerializeField] public ItemSO item;
        public InventoryItem inventoryItem;
        private void Awake()
        {
            Instance = this;
            // ResetData();
            SetData(item.ItemImage, item.BackGround, item.Name + "\n" + item.Description);
            Deselect();
          //   Transformbtn = InventoryPage.Instance.actionPanel;
            // panelConfirm = InventoryPage.Instance.panel;

        }
        internal virtual
            InventoryItem GetItemAt()
        {
            return UsingItemController.Instance.inventoryData.inventoryItems[index];
        }
        public void ResetData()
        {
            //this.BackGround.gameObject.SetActive(false);

            empty = true;

        }
        public virtual void Select()
        {
            borderImage.enabled = true;
            transform.gameObject.SetActive(true);
            Transformbtn.Toggle(true);
            Transformbtn.transform.position = transform.position+ new Vector3(3.2f,0,0);
            //InventoryPageUsingItem.Instance.actionPanel.Toggle(true);
            //InventoryPageUsingItem.Instance.actionPanel.transform.position = transform.position;
            ActionItemShop.Instance.AddAction();
        }
        public void Deselect()
        {
            borderImage.enabled = false;
        }
        public void SetData(Sprite sprite, Sprite background, string description)
        {

            this.BackGround.gameObject.SetActive(true);
            this.Image.sprite = sprite;
            this.Description.text = description;
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
            //  Debug.Log(item.Name);
            // InventoryController.Instance.inventoryData.AddItem(item,1);
            //ActionItemShop.Instance.BuyItem(item, 1);
            ActionItemShop.Instance.item = this.item;
            Select();
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

