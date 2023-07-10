using Inventory.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    public static SkillController Instance;
    [SerializeField] private RectTransform contentPanel;
    public List<ActionbarUi> inventoryUiItems = new List<ActionbarUi>();
    public int currentlyDraggedItemIndex = -1;
    public event Action<int> OnDescriptionRequested,
            OnItemActionRequested,
            OnStartDragging;


    private void Start()
    {
        IntializeInventory();
    }

    public void IntializeInventory()
    {
        ActionbarUi[] items = GetComponentsInChildren<ActionbarUi>();
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

    private void HandleShowItemActions(ActionbarUi inventoryItemUI)
    {
        int index = inventoryUiItems.IndexOf(inventoryItemUI);

        if (index == -1)
        {
            return;
        }
        OnItemActionRequested?.Invoke(index);
    }

    private void HandleEndDrag(ActionbarUi inventoryItemUI)
    {

        ResetDraggedItem();
    }
    private void ResetDraggedItem()
    {
        currentlyDraggedItemIndex = -1;

    }
    private void HandleSwap(ActionbarUi inventoryItemUI)
    {
        int index = inventoryUiItems.IndexOf(inventoryItemUI);
        if (index == -1)
        {
            return;
        }
        HandleItemSelection(inventoryItemUI);
    }


    public void HandleItemSelection(ActionbarUi inventoryItemUI)
    {
        int index = inventoryUiItems.IndexOf(inventoryItemUI);

        if (index == -1)
            return;
        OnDescriptionRequested?.Invoke(index);

    }

    private void HandleBeginDrag(ActionbarUi inventoryItemUI)
    {
        int index = inventoryUiItems.IndexOf(inventoryItemUI);

        if (index == -1)
            return;
        currentlyDraggedItemIndex = index;
        HandleItemSelection(inventoryItemUI);
        OnStartDragging?.Invoke(index);
    }
}
