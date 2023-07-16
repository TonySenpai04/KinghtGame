using Inventory.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace Inventory.UI
{
    public class InventoryPage : Page
    {
        public static InventoryPage Instance;
        [SerializeField] private InventoryUiItem inventoryUiItem;
        public List<InventoryUiItem> inventoryUiItems = new List<InventoryUiItem>();
        [SerializeField]
        public ItemActionPanel panel;
        public TextMeshProUGUI textConfirm;
        public GameObject BtnClose;
        public event Action<int> OnDescriptionRequested,
         OnItemActionRequested,
         OnStartDragging;
        public event Action<int, int> OnSwapItems;
        public GameObject Player;

        private void Awake()
        {
            Instance = this;
            inventoryDescription.ResetDescription();
            mouseFollower.Toggle(false);
            textConfirm.gameObject.SetActive(false);
            panel.Toggle(false);
            BtnClose.SetActive(false);
        }
        public void SetInventoryData()
        {
            Player = GameObject.Find("player");
            InventorySO=Player.GetComponent<InventoryController>().inventoryData;
        }
        internal void UpdateDescription(int itemIndex, Sprite itemImage, string name, string description,Sprite background)
        {
            inventoryDescription.SetDescription(itemImage, name, description,background);
            DeselectAllItems();
            inventoryUiItems[itemIndex].Select();
        }
        internal void ResetAllItems()
        {
            foreach (var item in inventoryUiItems)
            {
                item.ResetData();
                item.Deselect();
            }
        }
        public void AddAction(string name,Action performAction,Action end)
        {
            actionPanel.AddButon(name, performAction,end);  
        }
        public void ResetSelection()
        {
            inventoryDescription.ResetDescription();
            DeselectAllItems();

        }
        public void ShowItemAction(int index)
        {
            actionPanel.Toggle(true);
            actionPanel.transform.position= inventoryUiItems[index].transform.position;
        }
        private void DeselectAllItems()
        {
            foreach (InventoryUiItem item in inventoryUiItems)
            {
                item.Deselect();
            }
            actionPanel.Toggle(false);
            panel.Toggle(false );
            textConfirm.gameObject.SetActive(false);
        }
       
        public void UpdateData(int itemIndex,
            Sprite itemImage, int itemQuantity, Sprite background)
        {
            if (inventoryUiItems.Count > itemIndex)
            {
                inventoryUiItems[itemIndex].SetData(itemImage, itemQuantity, background);
            }

        }
       
        public void CreateDraggedItem(Sprite sprite, int quantity,Sprite background)
        {
            mouseFollower.Toggle(true);
            mouseFollower.SetData(sprite, quantity, background);
        }
        public void IntializeInventory(int inventorysize)
        {
            for (int i = 0; i < inventorysize; i++)
            {
                InventoryUiItem item = Instantiate(inventoryUiItem, Vector3.zero, Quaternion.identity, transform);
                item.transform.SetParent(contentPanel);
                inventoryUiItems.Add(item);
                item.OnItemClicked += HandleItemSelection;
                item.OnItemBeginDrap += HandleBeginDrag;
                item.OnItemDropOn += HandleSwap;
                item.OnItemEndDrap += HandleEndDrag;
                item.OnRightMouseBtnClick += HandleShowItemActions;
            }

        }


        private void HandleShowItemActions(InventoryUiItem inventoryItemUI)
        {
           int  index = inventoryUiItems.IndexOf(inventoryItemUI);
            
            if (index == -1)
            {
                return;
            }
            OnItemActionRequested?.Invoke(index);
        }

        private void HandleEndDrag(InventoryUiItem inventoryItemUI)
        {

            ResetDraggedItem();
        }
        private void ResetDraggedItem()
        {
            mouseFollower.Toggle(false);
            currentlyDraggedItemIndex = -1;
            
        }
        private void HandleSwap(InventoryUiItem inventoryItemUI)
        {
            int index = inventoryUiItems.IndexOf(inventoryItemUI);
            if (index == -1)
            {
                return;
            }
            OnSwapItems?.Invoke(currentlyDraggedItemIndex, index);
            HandleItemSelection(inventoryItemUI);
        }
       

        public void HandleItemSelection(InventoryUiItem inventoryItemUI)
        {
            int index = inventoryUiItems.IndexOf(inventoryItemUI);
            InventoryUiItem.Instance.index = index;
            if (index == -1) 
                return;
            OnDescriptionRequested?.Invoke(index);
        }


        private void HandleBeginDrag(InventoryUiItem inventoryItemUI)
        {
            int index = inventoryUiItems.IndexOf(inventoryItemUI);
            if (index == -1)
                return;
            currentlyDraggedItemIndex = index;
            HandleItemSelection(inventoryItemUI);
            OnStartDragging?.Invoke(index);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            ResetSelection();
            AnimationPlayer.instance.IsSkill1 = false;
            foreach (var item in InventorySO.GetCurrentInventoryState())
            {
                UpdateData(item.Key,
                    item.Value.item.ItemImage,
                    item.Value.quantity, item.Value.item.BackGround);
            }
            BtnClose.SetActive(true);
        }
        public void Hide()
        {
            gameObject.SetActive(false);
            actionPanel.Toggle(false);
            panel.Toggle(false);
            textConfirm.gameObject.SetActive(false);
            ResetDraggedItem();
            BtnClose.SetActive(false);
        }
    }
}