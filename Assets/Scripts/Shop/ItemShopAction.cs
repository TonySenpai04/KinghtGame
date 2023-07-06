using Inventory.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory.UI
{
    public class ActionItemShop : ItemAction
    {
        public static new ActionItemShop Instance;
        [SerializeField] public ItemSO item;
        public GameObject PanelNotification;
        public TextMeshProUGUI TxtNotification;

        public new void Start()
        {
            Instance = this;
            PanelNotification=ShopItemPage.Instance.PanelNotification;
            TxtNotification=ShopItemPage.Instance.TxtNotification;
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
            UiItemShop.Instance.transformPannelAction.AddButon("Buy", () => BuyItem(item, 1), () => ResetData()); 
            UiItemShop.Instance.transformPannelAction.AddButon("Close", () => ResetData(), () => UiItemShop.Instance.transformPannelAction.Toggle(false));

        }
        public void BuyItem(ItemSO item,int quatity)
        {
            if (item.type.ToString() == "Gold")
            {
                if (Gold_Diamond.instance.Gold >= ShopItemPage.Instance.inventoryUiItems[UiItemShop.Instance.index].Price)
                {
                    InventoryController.Instance.inventoryData.AddItem(item, quatity);
                    Gold_Diamond.instance.Gold -= ShopItemPage.Instance.inventoryUiItems[UiItemShop.Instance.index].Price;
                    ShopItemPage.Instance.TxtNotification.color = Color.black;
                    ShopItemPage.Instance.TxtNotification.text = "successfully purchase " + item.Name;
                    ShopItemPage.Instance.PanelNotification.SetActive(true);
                    StartCoroutine(SetEnabled());
                }
                else
                {
                    ShopItemPage.Instance.TxtNotification.color = Color.black;
                    ShopItemPage.Instance.TxtNotification.text = "You don't have enough gold!";
                    ShopItemPage.Instance.PanelNotification.SetActive(true);
                    StartCoroutine(SetEnabled());

                }
            }
            else
            {
                if (Gold_Diamond.instance.Diamond >= ShopItemPage.Instance.inventoryUiItems[UiItemShop.Instance.index].Price)
                {
                    InventoryController.Instance.inventoryData.AddItem(item, quatity);
                    Gold_Diamond.instance.Diamond -= ShopItemPage.Instance.inventoryUiItems[UiItemShop.Instance.index].Price;
                    ShopItemPage.Instance.TxtNotification.color = Color.black;
                    ShopItemPage.Instance.TxtNotification.text = "successfully purchase " + item.Name;
                    ShopItemPage.Instance.PanelNotification.SetActive(true);
                    StartCoroutine(SetEnabled());
                }
                else
                {
                    ShopItemPage.Instance.TxtNotification.color = Color.black;
                    ShopItemPage.Instance.TxtNotification.text = "You don't have enough diamond!";
                    ShopItemPage.Instance.PanelNotification.SetActive(true);
                    StartCoroutine(SetEnabled());

                }
            }
        }
        public IEnumerator SetEnabled()
        {
            yield return new WaitForSeconds(3);
            PanelNotification.SetActive(false);
        }
        public void ResetData()
        {
            ShopItemPage.Instance.Hide();
            
        }
    }
}