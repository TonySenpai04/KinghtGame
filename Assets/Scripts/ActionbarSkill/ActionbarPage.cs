using Inventory.Model;
using Inventory.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActionbarPage : MonoBehaviour
{
    [SerializeField] public ActionbarUi actionBarUI;
    [SerializeField] private RectTransform contentPanel;

    public List<ActionbarUi> actionList=new List<ActionbarUi>();
    private int currentlyDraggedItemIndex = -1;
    public event Action<int> OnDescriptionRequested,
            OnItemActionRequested,
            OnStartDragging;
    public event Action<int, int> OnSwapItems;

    private void Awake()
    {
        IntializeInventory();
    }
    private void Start()
    {
        

    }
    public void Componets()
    {
        if (this.actionList.Count > 0) return;
        ActionbarUi[] skill= GetComponentsInChildren<ActionbarUi>();
        this.actionList.AddRange(skill);
    }
 
    public void IntializeInventory()
    {
        ActionbarUi[] skill = GetComponentsInChildren<ActionbarUi>();
        this.actionList.AddRange(skill);
        foreach (var item in actionList)
        {
            //ActionbarUi item = Instantiate(actionBarUI, Vector3.zero, Quaternion.identity, transform);     
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
        int index = actionList.IndexOf(inventoryItemUI);
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
        int index = actionList.IndexOf(inventoryItemUI);
        if (index == -1)
        {
            return;
        }
        OnSwapItems?.Invoke(currentlyDraggedItemIndex, index);
        HandleItemSelection(inventoryItemUI);
    }


    public void HandleItemSelection(ActionbarUi inventoryItemUI)
    {
        int index = actionList.IndexOf(inventoryItemUI);
        if (index == -1)
            return;
        OnDescriptionRequested?.Invoke(index);

    }


    private void HandleBeginDrag(ActionbarUi inventoryItemUI)
    {
        int index = actionList.IndexOf(inventoryItemUI);
        if (index == -1)
            return;
        currentlyDraggedItemIndex = index;
        HandleItemSelection(inventoryItemUI);
        OnStartDragging?.Invoke(index);
    }


}
