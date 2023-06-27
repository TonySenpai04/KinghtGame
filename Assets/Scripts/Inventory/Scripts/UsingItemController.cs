using Inventory.Model;
using Inventory.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

namespace Inventory
{
    public class UsingItemController : MonoBehaviour
    {
        public static UsingItemController Instance;
        [SerializeField]
        private InventoryPageUsingItem inventoryUI;

        [SerializeField]
        public InventorySO inventoryData;
        public int CountItem = 0;
        public List<InventoryItem> initialItems = new List<InventoryItem>();


        private void Start()
        {
            PrepareUI();
            PrepareInventoryData();
            Setindex();
            Instance=this;
            
        } 
        public void PrepareInventoryData()
        {
            inventoryData.Initialize();
            inventoryData.OnInventoryUpdated += UpdateInventoryUI;
            foreach (InventoryItem item in initialItems)
            {
                if (item.IsEmpty)
                    continue;
                inventoryData.AddItem(item); 
              //  CountItem++;
               //Debug.Log(CountItem);
            }
 
        }
        

        public void Setindex()
        {
           
            for (int i = 0; i < CountItem-1; i++)
            {
                if (initialItems[i].item.index> initialItems[i + 1].item.index)
                {
                    
                    (initialItems[i + 1], initialItems[i]) = (initialItems[i], initialItems[i + 1]);
                    inventoryData.SwapItems(i, i + 1);
                }
            }
        }

        private void UpdateInventoryUI(Dictionary<int, InventoryItem> inventoryState)
        {
            inventoryUI.ResetAllItems();
            foreach (var item in inventoryState)
            {
                inventoryUI.UpdateData(item.Key, item.Value.item.ItemImage,
                    item.Value.quantity, item.Value.item.BackGround) ;
            }
        }

        private void PrepareUI()
        {
            inventoryUI.IntializeInventory(inventoryData.Size);
            inventoryUI.OnDescriptionRequested += HandleDescriptionRequest;
            inventoryUI.OnSwapItems += HandleSwapItems;
            inventoryUI.OnStartDragging += HandleDragging;
            inventoryUI.OnItemActionRequested += HandleItemActionRequest;
        }

        private void HandleItemActionRequest(int itemIndex)
        {
            InventoryItem inventoryItem = inventoryData.GetItemAt(itemIndex);
            if (inventoryItem.IsEmpty)
                return;

            IItemAction itemAction = inventoryItem.item as IItemAction;
            if (itemAction != null)
            {

                inventoryUI.ShowItemAction(itemIndex);
                inventoryUI.AddAction(itemAction.ActionName, () => PerformAction(itemIndex),null);
            }

            IDestroyableItem destroyableItem = inventoryItem.item as IDestroyableItem;
            if (destroyableItem != null)
            {
                inventoryUI.AddAction("Drop", () => DropItem(itemIndex, inventoryItem.quantity), null);
            }
        }

        private void DropItem(int itemIndex, int quantity)
        {
            inventoryData.RemoveItem(itemIndex, quantity);
            inventoryUI.ResetSelection();
        }

        public void PerformAction(int itemIndex)
        {
            InventoryItem inventoryItem = inventoryData.GetItemAt(itemIndex);
            if (inventoryItem.IsEmpty)
                return;

            IDestroyableItem destroyableItem = inventoryItem.item as IDestroyableItem;
            if (destroyableItem != null)
            {
                inventoryData.RemoveItem(itemIndex, 1);
            }

            IItemAction itemAction = inventoryItem.item as IItemAction;
            if (itemAction != null)
            {
                itemAction.PerformAction(gameObject, inventoryItem.itemState);
                //audioSource.PlayOneShot(itemAction.actionSFX);
                if (inventoryData.GetItemAt(itemIndex).IsEmpty)
                    inventoryUI.ResetSelection();
            }
        }

        private void HandleDragging(int itemIndex)
        {
            InventoryItem inventoryItem = inventoryData.GetItemAt(itemIndex);
            if (inventoryItem.IsEmpty)
                return;
            inventoryUI.CreateDraggedItem(inventoryItem.item.ItemImage, inventoryItem.quantity, inventoryItem.item.BackGround);
        }

        private void HandleSwapItems(int itemIndex_1, int itemIndex_2)
        {
            ///nventoryData.SwapItems(itemIndex_1, itemIndex_2);
        }

        private void HandleDescriptionRequest(int itemIndex)
        {
            InventoryItem inventoryItem = inventoryData.GetItemAt(itemIndex);
            if (inventoryItem.IsEmpty)
            {
                inventoryUI.ResetSelection();
                return;
            }
            ItemSO item = inventoryItem.item;
            string description = PrepareDescription(inventoryItem);
            inventoryUI.UpdateDescription(itemIndex, item.ItemImage,
                item.name, description,item.BackGround);
        }

        private string PrepareDescription(InventoryItem inventoryItem)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(inventoryItem.item.Description);
            sb.AppendLine();
            for (int i = 0; i < inventoryItem.itemState.Count; i++)
            {
                sb.Append($"{inventoryItem.itemState[i].itemParameter.ParameterName} " +
                    $": {inventoryItem.itemState[i].value} / " +
                    $"{inventoryItem.item.DefaultParametersList[i].value}");
                sb.AppendLine();
            }
            return sb.ToString();
        }
        public void RemoveItem(int index,int mount)
        {
            inventoryData.RemoveItem(index,mount);
            InventoryPage.Instance.textConfirm.gameObject.SetActive(false);

        }

        public void Update()
        {

            Setindex();
            if (Input.GetKeyDown(KeyCode.I))
            {
               
                if (inventoryUI.isActiveAndEnabled == false)
                {
                    inventoryUI.Show();
                    foreach (var item in inventoryData.GetCurrentInventoryState())
                    {
                        inventoryUI.UpdateData(item.Key,
                            item.Value.item.ItemImage,
                            item.Value.quantity,item.Value.item.BackGround);
                    }
                }
                else
                {
                    inventoryUI.Hide();
                }

            }
        }
    }
}