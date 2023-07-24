using Inventory.Model;
using Inventory.UI;
using System;
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
        public List<InventoryItem> initialItems = new List<InventoryItem>();


        private void Start()
        {
            Instance = this;
            inventoryData = inventoryUI.InventorySO;
            PrepareUI();           
        }
        public void PrepareInventoryData()
        {
            inventoryData.Initialize();
            foreach (InventoryItem item in initialItems)
            {
                if (item.IsEmpty)
                    continue;
                inventoryData.AddItem(item);
            }

        }


        private void UpdateInventoryUI(Dictionary<int, InventoryItem> inventoryState)
        {
            inventoryUI.ResetAllItems();
            foreach (var item in inventoryState)
            {
                inventoryUI.UpdateData(item.Key, item.Value.item.ItemImage,
                    item.Value.quantity, item.Value.item.BackGround);
            }
        }

        private void PrepareUI()
        {
            inventoryData.OnInventoryUpdated += UpdateInventoryUI;
            inventoryUI.IntializeInventory();
            inventoryUI.OnDescriptionRequested += HandleDescriptionRequest;
            inventoryUI.OnSwapItems += HandleSwapItems;
            inventoryUI.OnStartDragging += HandleDragging;
            inventoryUI.OnItemActionRequested += HandleItemActionRequest;
        }

        private void HandleItemActionRequest(int itemIndex)
        {
            
        }

        private void DropItem(int itemIndex, int quantity)
        {
            inventoryData.RemoveItem(itemIndex, quantity);
            inventoryUI.ResetSelection();
        }

        public void PerformAction(int itemIndex)
        {
            
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


    }
}