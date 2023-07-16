using Inventory.Model;
using System;
using System.CodeDom.Compiler;
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
        public ShopItemPage shop;

        public new void Start()
        {
            Instance = this;
            PanelNotification=shop.PanelNotification;
            TxtNotification=shop.TxtNotification;
        }
      
        public override void AddButon(string name, Action onClickAction)
        {
            GameObject button = Instantiate(buttonPrefab, transform);
            button.GetComponent<Button>().onClick.AddListener(() => onClickAction());
            button.GetComponentInChildren<TMPro.TMP_Text>().text = name;

        }
        public override void AddAction()
        {
            UiItemShop.Instance.transformPannelAction.AddButon("Buy", () => BuyItem(this.item, 1), () => ResetData()); 
            UiItemShop.Instance.transformPannelAction.AddButon("Close", () => ResetData(), () => UiItemShop.Instance.transformPannelAction.Toggle(false));

        }
        public void BuyItem(ItemSO item,int quantity)
        {
            if (item.type ==Type.Gold)
            {
                BuyGold(item, quantity);
                PlayerData.Intance.characterData.Gold = (int)Gold_Diamond.instance.Gold;
            }
            else
            {
                BuyDiamond(item, quantity);
                PlayerData.Intance.characterData.Diamond = (int)Gold_Diamond.instance.Diamond;
            }
        }
        public IEnumerator SetEnabled()
        {
            yield return new WaitForSeconds(2);
            shop.PanelNotification.SetActive(false);
        }
        public void ResetData()
        {
            shop.Hide();
            
        }
        public void BuyGold(ItemSO item, int quantity)
        {
            if (Gold_Diamond.instance.Gold >= shop.inventoryUiItems[UiItemShop.Instance.index].Price)
            {
                if (item.Name == "Bottle Hp")
                {

                    HPController.Instance.currentBottle += 1;
                    Gold_Diamond.instance.Gold -= shop.inventoryUiItems[UiItemShop.Instance.index].Price;
                    shop.TxtNotification.color = Color.black;
                    shop.TxtNotification.text = "successfully purchase " + item.Name;
                    shop.PanelNotification.SetActive(true);
                    StartCoroutine(SetEnabled());
                }
                else if (item.Name == "Bottle Mp")
                {
                    MPController.Instance.CurrentBottle += 1;
                    Gold_Diamond.instance.Gold -= shop.inventoryUiItems[UiItemShop.Instance.index].Price;
                    shop.TxtNotification.color = Color.black;
                    shop.TxtNotification.text = "successfully purchase " + item.Name;
                    shop.PanelNotification.SetActive(true);
                    StartCoroutine(SetEnabled());
                }
                else
                {
                    InventoryController.Instance.inventoryData.AddItem(item, quantity);
                    Gold_Diamond.instance.Gold -= shop.inventoryUiItems[UiItemShop.Instance.index].Price;
                    shop.TxtNotification.color = Color.black;
                    shop.TxtNotification.text = "successfully purchase " + item.Name;
                    shop.PanelNotification.SetActive(true);
                    StartCoroutine(SetEnabled());
                }
            }
            else
            {
                shop.TxtNotification.color = Color.black;
                shop.TxtNotification.text = "You don't have enough gold!";
                shop.PanelNotification.SetActive(true);
                StartCoroutine(SetEnabled());
            }
        }
        public void BuyDiamond(ItemSO item, int quantity)
        {
            if (Gold_Diamond.instance.Diamond >= shop.inventoryUiItems[UiItemShop.Instance.index].Price)
            {
                InventoryController.Instance.inventoryData.AddItem(item, quantity);
                Gold_Diamond.instance.Diamond -= shop.inventoryUiItems[UiItemShop.Instance.index].Price;
                shop.TxtNotification.color = Color.black;
                shop.TxtNotification.text = "successfully purchase " + item.Name;
                shop.PanelNotification.SetActive(true);
                StartCoroutine(SetEnabled());
            }
            else
            {
                shop.TxtNotification.color = Color.black;
                shop.TxtNotification.text = "You don't have enough diamond!";
                shop.PanelNotification.SetActive(true);
                StartCoroutine(SetEnabled());

            }
        }
    }

}