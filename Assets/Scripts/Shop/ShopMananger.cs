using Inventory.Model;
using Inventory.UI;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Pool;

public class ShopMananger : MonoBehaviour
{
    public GameObject[] itemPanels;
    public GameObject currentItemPanel;
    public GameObject PanelShop;
    public ShopItemPage[] pagge;
    void Start()
    {
        foreach (GameObject itemPanel in itemPanels)
        {
            itemPanel.SetActive(false);
        }
    }
    public void OpenItemPanel(int itemIndex)
    {
        if (currentItemPanel != null)
        {
            currentItemPanel.SetActive(false);
        }
        GameObject itemPanel = itemPanels[itemIndex];
        ShopItemPage pagg = pagge[itemIndex];
        itemPanel.SetActive(true);
        ActionItemShop.Instance.shop= pagg;
        currentItemPanel = itemPanel;
    }
    public void CloseItemPanel()
    {
         
        foreach (GameObject itemPanel in itemPanels)
        {
            PanelShop.SetActive(false);
            itemPanel.SetActive(false);
            itemPanel.GetComponentInChildren<ShopItemPage>().Hide();
        }
    }
 

}
