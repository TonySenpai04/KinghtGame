using Inventory.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


namespace Inventory.UI
{
    public class ItemAction : MonoBehaviour
    {
        public static ItemAction Instance;
        [SerializeField] protected GameObject buttonPrefab;
        public  void Start()
        {
            Instance = this;
            buttonPrefab = InventoryUiItem.Instance.buttonPrefab;
        }
        public virtual void DropItem(int itemIndex, int quantity)
        {
           
            InventoryPage.Instance.ResetSelection();
            AddActionPanelConfirm();
            InventoryUiItem.Instance. inventoryItem = InventoryUiItem.Instance. GetItemAt();
        }
        public virtual void AddActionPanelConfirm()
        {
           
            InventoryPage.Instance.textConfirm.text = "Are you sure you want to drop this item?";
            InventoryPage.Instance.textConfirm.gameObject.SetActive(true);
            InventoryUiItem.Instance.panelConfirm.Toggle(true);
            InventoryUiItem.Instance.panelConfirm.AddButon("Yes", () => InventoryController.Instance.RemoveItem(InventoryUiItem.Instance.index, InventoryUiItem.Instance.inventoryItem.quantity),()=>InventoryPage.Instance.panel.Toggle(false) );
            InventoryUiItem.Instance.panelConfirm.AddButon("No", () => SetActivePanel(), () => InventoryPage.Instance.textConfirm.text="");

        }
        public void SetActivePanel()
        {
            InventoryUiItem.Instance.panelConfirm.Toggle(false);
        }
        public virtual void AddButon(string name, Action onClickAction)
        {
            GameObject button = Instantiate(buttonPrefab, transform);
            button.GetComponent<Button>().onClick.AddListener(() => onClickAction());
            button.GetComponentInChildren<TMPro.TMP_Text>().text = name;

        }
        public virtual void AddAction()
        {
            InventoryUiItem.Instance. Transformbtn.AddButon("Drop", () => DropItem(InventoryUiItem.Instance.index, InventoryUiItem.Instance. inventoryItem.quantity),()=> InventoryPage.Instance.actionPanel.Toggle(false));
            InventoryUiItem.Instance. Transformbtn.AddButon("Equip", () => Equip(), () => InventoryPage.Instance.actionPanel.Toggle(false));

        }
        public virtual void Equip()
        {
            InventoryPage.Instance.ResetSelection();
            InventoryItem inventoryItem = InventoryController.Instance.inventoryData.GetItemAt(InventoryUiItem.Instance.index);
            IItemAction itemAction =  inventoryItem.item as IItemAction;
            itemAction.PerformAction(gameObject, null);
            InventoryUiItem.Instance.inventoryItem = InventoryUiItem.Instance.GetItemAt();
            InventoryController.Instance.inventoryUI.ShowItemAction(InventoryUiItem.Instance.index);
            InventoryController.Instance.inventoryData.RemoveItem(InventoryUiItem.Instance.index, 1);
            for (int i = 0; i < 6; i++)
            {
                
                    InventoryPageUsingItem.Instance.inventoryUiItems[i].inventoryItem = inventoryItem;

                    switch (InventoryPageUsingItem.Instance.inventoryUiItems[i].inventoryItem.item.index)
                    {
                        case 0:
                        if (InventoryPageUsingItem.Instance.InventorySO.inventoryItems[0].item == null)
                        {
                            SetInddexItem(inventoryItem, i, 0);
                            return;
                        }
                        else
                        {
                            ChangeItem(inventoryItem, itemAction, 0);
                            SetInddexItem(inventoryItem, i, 0);
                            return;
                        }
                        case 1:
                        if (InventoryPageUsingItem.Instance.InventorySO.inventoryItems[1].item == null)
                        {
                            SetInddexItem(inventoryItem, i, 1);
                            return;
                        }
                        else
                        {
                            ChangeItem(inventoryItem, itemAction, 1);
                            SetInddexItem(inventoryItem, i, 1);
                            return;
                        }
                        case 2:
                        if (InventoryPageUsingItem.Instance.InventorySO.inventoryItems[2].item == null)
                        {
                            SetInddexItem(inventoryItem, i, 2);
                            return;
                        }
                        else
                        {
                            ChangeItem(inventoryItem, itemAction, 2);
                            SetInddexItem(inventoryItem, i, 2);
                            return;
                        }
                        case 3:
                        if (InventoryPageUsingItem.Instance.InventorySO.inventoryItems[3].item == null)
                        {
                            SetInddexItem(inventoryItem, i, 3);
                            return;
                        }
                        else
                        {
                            ChangeItem(inventoryItem, itemAction, 3);
                            SetInddexItem(inventoryItem, i, 3);
                            return;
                        }
                        case 4:
                        if (InventoryPageUsingItem.Instance.InventorySO.inventoryItems[4].item == null)
                        {
                            SetInddexItem(inventoryItem, i, 4);
                            return;
                        }
                        else
                        {
                            ChangeItem(inventoryItem, itemAction, 4);
                            SetInddexItem(inventoryItem, i, 4);
                            return;
                        }
                        case 5:
                        if (InventoryPageUsingItem.Instance.InventorySO.inventoryItems[5].item == null)
                        {
                            SetInddexItem(inventoryItem, i, 5);
                            return;
                        }
                        else
                        {
                            ChangeItem(inventoryItem, itemAction, 5);
                            SetInddexItem(inventoryItem, i, 5);
                            return;
                        }
                        


                }
            }


        }
        public void SetInddexItem(InventoryItem inventoryItem,int i,int index)
        {
            InventoryPageUsingItem.Instance.InventorySO.inventoryItems[index] = InventoryPageUsingItem.Instance.inventoryUiItems[i].inventoryItem;
            foreach (var item in InventoryPageUsingItem.Instance.InventorySO.GetCurrentInventoryState())
            {
                InventoryPageUsingItem.Instance.UpdateData(item.Key,
                    item.Value.item.ItemImage,
                    item.Value.quantity,item.Value.item.BackGround);
            }

        }
        public void ChangeItem(InventoryItem inventoryItem, IItemAction itemAction,int index)
        {
            inventoryItem = UsingItemController.Instance.inventoryData.GetItemAt(index);
            itemAction = inventoryItem.item as IItemAction;
            itemAction.PerformActionRemove(gameObject, null);
            InventoryPageUsingItem.Instance.ResetSelection();
            InventoryController.Instance.inventoryData.AddItem(InventoryPageUsingItem.Instance.InventorySO.inventoryItems[index]);
            UsingItemController.Instance.RemoveItem(index, InventoryItemUsing.Instance.inventoryItem.quantity);
        }

    }
}
