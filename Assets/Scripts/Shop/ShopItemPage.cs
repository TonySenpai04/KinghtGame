using Inventory.Model;
using Inventory.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ShopItemPage : MonoBehaviour
{
    public static ShopItemPage Instance;
    [SerializeField] private UiItemShop inventoryUiItem;
    [SerializeField] private RectTransform contentPanel;
  
    public List<UiItemShop> inventoryUiItems = new List<UiItemShop>();
    [SerializeField]
    public ItemActionPanel actionPanel;
    [SerializeField]
   // public ItemActionPanel panel;
    public int currentlyDraggedItemIndex = -1;
    public event Action<int> OnDescriptionRequested,
            OnItemActionRequested,
            OnStartDragging;
    public event Action<int, int> OnSwapItems;
    public GameObject PanelNotification;
    public TextMeshProUGUI TxtNotification;
    private void Awake()
    {
        Instance = this;

    }
    private void Start()
    {
        IntializeInventory();
    }

    internal void UpdateDescription(int itemIndex)
    {
       
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
    public void AddAction()
    {
        actionPanel.AddButon("Buy", () =>ActionItemShop.Instance. BuyItem(inventoryUiItem.item, 1), () => UiItemShop.Instance.transformPannelAction.Toggle(false));
        actionPanel.AddButon("Close", () => UiItemShop.Instance.transformPannelAction.Toggle(false), () => UiItemShop.Instance.transformPannelAction.Toggle(false));
    }
    public void ResetSelection()
    {
      
        DeselectAllItems();
    }
    public void ShowItemAction(int index)
    {
    
        actionPanel.Toggle(true);
        actionPanel.transform.position = inventoryUiItems[index].transform.position;
    }
    private void DeselectAllItems()
    {
        foreach (UiItemShop item in inventoryUiItems)
        {
            item.Deselect();
        }
        actionPanel.Toggle(false);
    }

    public void UpdateData(int itemIndex,
        Sprite itemImage, Sprite background,string description)
    {
        if (inventoryUiItems.Count > itemIndex)
        {
            inventoryUiItems[itemIndex].SetData(itemImage, background,description);
        }

    }

    public void CreateDraggedItem(Sprite sprite, int quantity, Sprite background)
    {
        
    }
    public void IntializeInventory()
    {

        UiItemShop[] items = GetComponentsInChildren<UiItemShop>();
        inventoryUiItems.AddRange(items);
        foreach (var item in inventoryUiItems)
        {
            item.transform.SetParent(contentPanel);
            item.OnItemClicked += HandleItemSelection;
            item.OnItemBeginDrap += HandleBeginDrag;
            item.OnItemDropOn += HandleSwap;
            item.OnItemEndDrap += HandleEndDrag;
            item.OnRightMouseBtnClick += HandleShowItemActions;
        }

    }
    private void HandleEndDrag(UiItemShop inventoryItemUI)
    {

        ResetDraggedItem();
    }


    private void HandleShowItemActions(UiItemShop inventoryItemUI)
    {
        int index = inventoryUiItems.IndexOf(inventoryItemUI);

        if (index == -1)
        {
            return;
        }
        OnItemActionRequested?.Invoke(index);
    }

    
    private void ResetDraggedItem()
    {
       
        currentlyDraggedItemIndex = -1;
        DeselectAllItems();

    }
   
    private void HandleSwap(UiItemShop inventoryItemUI)
    {
        int index = inventoryUiItems.IndexOf(inventoryItemUI);
        if (index == -1)
        {
            return;
        }
        OnSwapItems?.Invoke(currentlyDraggedItemIndex, index);
        HandleItemSelection(inventoryItemUI);
    }


    public void HandleItemSelection(UiItemShop inventoryItemUI)
    {
        int index = inventoryUiItems.IndexOf(inventoryItemUI);
        UiItemShop.Instance.index=index;
        ActionItemShop.Instance.item = inventoryUiItems[index].item;
        AddAction();
        UpdateDescription(index);
        if (index == -1)
            return;
        OnDescriptionRequested?.Invoke(index);

    }


    private void HandleBeginDrag(UiItemShop inventoryItemUI)
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
        actionPanel.Toggle(false);
        ResetDraggedItem();
       
    }
}
