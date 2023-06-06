using Inventory.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Inventory.UI
{
    public class InventoryPageUsingItem : MonoBehaviour
    {
        public static InventoryPageUsingItem Instance;
       
        
         
            [SerializeField] private InventoryItemUsing inventoryUiItem;
            [SerializeField] private RectTransform contentPanel;
            [SerializeField] InventoryDescription inventoryDescription;
            public InventorySO InventorySO;
            public List<InventoryItemUsing> inventoryUiItems = new List<InventoryItemUsing>();
            public MouseFollower mouseFollower;
            [SerializeField]
            public ItemActionPanel actionPanel;
          
            

            private void Awake()
            {
            Instance = this;
                inventoryDescription.ResetDescription();
                mouseFollower.Toggle(false);
            }
            public int currentlyDraggedItemIndex = -1;
            public event Action<int> OnDescriptionRequested,
                    OnItemActionRequested,
                    OnStartDragging;
            public event Action<int, int> OnSwapItems;


            internal void UpdateDescription(int itemIndex, Sprite itemImage, string name, string description)
            {
                inventoryDescription.SetDescription(itemImage, name, description);
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
            public void AddAction(string name, Action performAction,Action end)
            {
                actionPanel.AddButon(name, performAction, end);
            }
            public void ResetSelection()
            {
                inventoryDescription.ResetDescription();
                DeselectAllItems();

            }
            public void ShowItemAction(int index)
            {
                actionPanel.Toggle(true);
                actionPanel.transform.position = inventoryUiItems[index].transform.position;
            }
            private void DeselectAllItems()
            {
                foreach (InventoryItemUsing item in inventoryUiItems)
                {
                    item.Deselect();
                }
                actionPanel.Toggle(false);
            }
            public void UpdateData(int itemIndex,
                Sprite itemImage, int itemQuantity)
            {
                if (inventoryUiItems.Count > itemIndex)
                {
                    inventoryUiItems[itemIndex].SetData(itemImage, itemQuantity);
                }

            }

            public void CreateDraggedItem(Sprite sprite, int quantity)
            {
                mouseFollower.Toggle(true);
                mouseFollower.SetData(sprite, quantity);
            }
            public void IntializeInventory(int inventorysize)
            {
                for (int i = 0; i < inventorysize; i++)
                {
                   InventoryItemUsing item = Instantiate(inventoryUiItem, Vector3.zero, Quaternion.identity, transform);
                    item.transform.SetParent(contentPanel);
                    inventoryUiItems.Add(item);
                    item.OnItemClicked += HandleItemSelection;
                    item.OnItemBeginDrap += HandleBeginDrag;
                    item.OnItemDropOn += HandleSwap;
                    item.OnItemEndDrap += HandleEndDrag;
                    item.OnRightMouseBtnClick += HandleShowItemActions;
                }

            }


            private void HandleShowItemActions(InventoryItemUsing inventoryItemUI)
            {
                int index = inventoryUiItems.IndexOf(inventoryItemUI);
                if (index == -1)
                {
                    return;
                }
                OnItemActionRequested?.Invoke(index);
            }

            private void HandleEndDrag(InventoryItemUsing inventoryItemUI)
            {

                ResetDraggedItem();
            }
            private void ResetDraggedItem()
            {
                mouseFollower.Toggle(false);
                currentlyDraggedItemIndex = -1;
            }
            private void HandleSwap(InventoryItemUsing inventoryItemUI)
            {
                int index = inventoryUiItems.IndexOf(inventoryItemUI);
                if (index == -1)
                {
                    return;
                }
                OnSwapItems?.Invoke(currentlyDraggedItemIndex, index);
                HandleItemSelection(inventoryItemUI);
            }


            public void HandleItemSelection(InventoryItemUsing inventoryItemUI)
            {
                int index = inventoryUiItems.IndexOf(inventoryItemUI);
            InventoryItemUsing.Instance.index=index;
                InventoryItemUsing.Instance.index=index;
                if (index == -1)
                    return;
                OnDescriptionRequested?.Invoke(index);

            }


            private void HandleBeginDrag(InventoryItemUsing inventoryItemUI)
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
                // actionPanel.Toggle(true);
            }
            public void Hide()
            {
                gameObject.SetActive(false);
                actionPanel.Toggle(false);
                ResetDraggedItem();
                AnimationPlayer.instance.IsSkill1 = true;
            }
        }

    }

