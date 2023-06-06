using Inventory.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;


namespace Inventory.UI
{
    public class ItemAction : MonoBehaviour
    {
        public static ItemAction Instance;
       // private InventorySO inventoryData;
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
            InventoryUiItem.Instance.panelConfirm.AddButon("No", () => InventoryUiItem.Instance.panelConfirm.Toggle(false), () => InventoryPage.Instance.textConfirm.text="");

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
            InventoryUiItem.Instance.inventoryItem = InventoryUiItem.Instance.GetItemAt();
            InventoryPageUsingItem.Instance.InventorySO.AddItem(GetComponent<InventoryUiItem>().inventoryItem);
            InventoryController.Instance.inventoryData.RemoveItem(InventoryUiItem.Instance.index, InventoryUiItem.Instance.inventoryItem.quantity);


        }
    }
}
