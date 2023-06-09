using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Inventory.Model;


namespace Inventory.UI
{
    public class InventoryUiItem : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IEndDragHandler, IDropHandler, IDragHandler
    {
        public  static InventoryUiItem Instance;
        [SerializeField] protected Image Image;
        [SerializeField] protected TextMeshProUGUI quantitytext;
        [SerializeField] public Image borderImage;
        [SerializeField] public GameObject buttonPrefab;
        [SerializeField] public ItemActionPanel Transformbtn;
        public event Action<InventoryUiItem> OnItemDropOn, OnItemBeginDrap, OnItemEndDrap, OnRightMouseBtnClick, OnItemClicked;
        [SerializeField] protected bool empty = true;
        [SerializeField] public int index;
        [SerializeField] public ItemActionPanel panelConfirm;
       // public int a;
        [SerializeField] protected Image BackGround;

        public InventoryItem inventoryItem;
        private void Awake()
        {
            Instance=this;
            ResetData();
            Deselect();
            Transformbtn = InventoryPage.Instance.actionPanel;
            panelConfirm = InventoryPage.Instance.panel;
        }
        
        internal virtual InventoryItem GetItemAt()
        {
            return InventoryController.Instance.inventoryData.inventoryItems[index];
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
            InventoryPage.Instance.actionPanel.Toggle(true);
            InventoryPage.Instance.actionPanel.transform.SetParent(transform);
            InventoryPage.Instance.actionPanel.transform.position = transform.position;
            ItemAction.Instance.AddAction();
           
        }      
        public void Deselect()
        {
            borderImage.enabled = false;
        }     
        public void SetData(Sprite sprite, int quatity,Sprite background)
        {

            this.BackGround.gameObject.SetActive(true);
            this.Image.sprite = sprite;
            this.BackGround.sprite = background;
            if (quatity > 1)
            {
                this.quantitytext.text = quatity.ToString();
            }
            else
            {
                this.quantitytext.text = "";
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
