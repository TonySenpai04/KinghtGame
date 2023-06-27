using Inventory.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory.UI
{
    public class ActionItemShop : ItemAction
    {
        public static new ActionItemShop Instance;
        // private InventorySO inventoryData;
        [SerializeField] public ItemSO item;
        public new void Start()
        {
            Instance = this;
          //  buttonPrefab = InventoryUiItem.Instance.buttonPrefab;
        }
        public override void DropItem(int itemIndex, int quantity)
        {

            InventoryPage.Instance.ResetSelection();
            AddActionPanelConfirm();
            InventoryUiItem.Instance.inventoryItem = InventoryUiItem.Instance.GetItemAt();
        }
        public override void AddActionPanelConfirm()
        {

        }
        public override void AddButon(string name, Action onClickAction)
        {
            GameObject button = Instantiate(buttonPrefab, transform);
            button.GetComponent<Button>().onClick.AddListener(() => onClickAction());
            button.GetComponentInChildren<TMPro.TMP_Text>().text = name;

        }
        public override void AddAction()
        {
            UiItemShop.Instance.Transformbtn.AddButon("Buy", () =>BuyItem(item,1), () => UiItemShop.Instance.Transformbtn.Toggle(false));
            UiItemShop.Instance.Transformbtn.AddButon("Close", () => UiItemShop.Instance.Transformbtn.Toggle(false), () => UiItemShop.Instance.Transformbtn.Toggle(false));

        }
        public void BuyItem(ItemSO item,int quatity)
        {
            InventoryController.Instance.inventoryData.AddItem(item, quatity);
        }
    }
}