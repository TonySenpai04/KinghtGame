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
    public class ItemActionUsing : ItemAction
    {
        public static new ItemActionUsing Instance;
        private new void Start()
        {
            Instance = this;
            buttonPrefab = InventoryItemUsing.Instance.buttonPrefab;
        }
        public override void AddButon(string name, Action onClickAction)
        {
            GameObject button = Instantiate(buttonPrefab, transform);
            button.GetComponent<Button>().onClick.AddListener(() => onClickAction());
            button.GetComponentInChildren<TMPro.TMP_Text>().text = name;
        }
        public override void DropItem(int itemIndex, int quantity)
        {

            InventoryPageUsingItem.Instance.ResetSelection();
            AddActionPanelConfirm();
            InventoryItemUsing.Instance.inventoryItem = InventoryItemUsing.Instance.GetItemAt();
            Audio.PlayOneShot(AudioPlayer.instance.ActionSound);

        }
        public override void AddActionPanelConfirm()
        {

            InventoryPage.Instance.textConfirm.text = "Are you sure you want to drop this item?";
            InventoryPage.Instance.textConfirm.gameObject.SetActive(true);
            InventoryItemUsing.Instance.panelConfirm.Toggle(true);
            InventoryItemUsing.Instance.panelConfirm.AddButon("Yes", () => RemoveFuncitionItem(InventoryItemUsing.Instance.index, InventoryItemUsing.Instance.inventoryItem.quantity), () => InventoryPage.Instance.panel.Toggle(false));
            InventoryItemUsing.Instance.panelConfirm.AddButon("No", () => SetActivePanel(), () => InventoryPage.Instance.textConfirm.text = "");

        }
        public void SetActivePannel()
        {
            InventoryItemUsing.Instance.panelConfirm.Toggle(false);
            Audio.PlayOneShot(AudioPlayer.instance.ActionSound);
        }
        public override void AddAction()
        {
            InventoryItemUsing.Instance.Transformbtn.AddButon("Remove", () => RemoveItem(), () => InventoryPageUsingItem.Instance.actionPanel.Toggle(false));
            InventoryItemUsing.Instance.Transformbtn.AddButon("Drop", () => DropItem(InventoryItemUsing.Instance.index, InventoryItemUsing.Instance.inventoryItem.quantity), () => InventoryPageUsingItem.Instance.actionPanel.Toggle(false));
        }
        public override void RemoveItem()
        {
            InventoryPageUsingItem.Instance.ResetSelection();
            InventoryItem inventoryItem = UsingItemController.Instance.inventoryData.GetItemAt(InventoryItemUsing.Instance.index);
            IItemAction itemAction = inventoryItem.item as IItemAction;
            Audio.PlayOneShot(AudioPlayer.instance.ActionSound);
            itemAction.PerformActionRemove(gameObject, inventoryItem.itemState);
            InventoryItemUsing.Instance.inventoryItem = InventoryItemUsing.Instance.GetItemAt();
            UsingItemController.Instance.RemoveItem(InventoryItemUsing.Instance.index, InventoryItemUsing.Instance.inventoryItem.quantity);
            InventoryController.Instance.inventoryData.AddItem(InventoryItemUsing.Instance.inventoryItem);
           
        }
        public void RemoveFuncitionItem(int index, int mount)
        {
            InventoryItem inventoryItem = UsingItemController.Instance.inventoryData.GetItemAt(InventoryItemUsing.Instance.index);
            IItemAction itemAction = inventoryItem.item as IItemAction;
            itemAction.PerformActionRemove(gameObject, null);
            UsingItemController.Instance.RemoveItem(index, mount);
            InventoryPage.Instance.textConfirm.gameObject.SetActive(false);
            Audio.PlayOneShot(AudioPlayer.instance.ActionSound);


        }
    }
}
