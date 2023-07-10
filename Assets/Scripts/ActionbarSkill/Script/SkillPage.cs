using Inventory.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillPage : MonoBehaviour
{
    public static SkillPage Instance;
    [SerializeField] private DescriptionSkillUI inventoryUiItem;
    [SerializeField] private RectTransform contentPanel;
    public List<DescriptionSkillUI> inventoryUiItems = new List<DescriptionSkillUI>();
    public int currentlyDraggedItemIndex = -1;
    public event Action<int> OnDescriptionRequested,
            OnItemActionRequested,
            OnStartDragging;
    public event Action<int, int> OnSwapItems;
    public ItemActionPanel actionPanel;
    public int PointSkill = 0;
    public Transform Player;
    private void Awake()
    {
        Instance = this;
 
    }
    private void Update()
    {
        Player = GameObject.Find("player").transform;
        inventoryUiItems[0].SkillPlayer = Player.GetComponent<AttackFunction>().skillS0[0];
        inventoryUiItems[1].SkillPlayer = Player.GetComponent<AttackFunction>().skillS0[1];
        inventoryUiItems[2].SkillPlayer = Player.GetComponent<AttackFunction>().skillS0[2];
        IntializeInventory();
    }
    private void Start()
    { 
        AddItem();
        Player = GameObject.Find("player").transform;
        inventoryUiItems[0].SkillPlayer = Player.GetComponent<AttackFunction>().skillS0[0];
        inventoryUiItems[1].SkillPlayer = Player.GetComponent<AttackFunction>().skillS0[1];
        inventoryUiItems[2].SkillPlayer = Player.GetComponent<AttackFunction>().skillS0[2];
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
        foreach (DescriptionSkillUI item in inventoryUiItems)
        {
            item.Deselect();
        }
        actionPanel.Toggle(false);
    }

    public void UpdateData(int itemIndex,
        Sprite itemImage, Sprite background, string description)
    {
        if (inventoryUiItems.Count > itemIndex)
        {
            inventoryUiItems[itemIndex].SetDescription(inventoryUiItems[itemIndex].SkillPlayer);
        }

    }

    public void AddItem()
    {
        DescriptionSkillUI[] items = GetComponentsInChildren<DescriptionSkillUI>();
        inventoryUiItems.AddRange(items);
    }
    public void IntializeInventory()
    {

        
        foreach (var item in inventoryUiItems)
        {
            item.SetDescription(item.SkillPlayer);
            item.transform.SetParent(contentPanel);
            item.OnItemClicked += HandleItemSelection;
            item.OnItemBeginDrap += HandleBeginDrag;
            item.OnItemDropOn += HandleSwap;
            item.OnItemEndDrap += HandleEndDrag;
            item.OnRightMouseBtnClick += HandleShowItemActions;
        }

    }
    private void HandleEndDrag(DescriptionSkillUI inventoryItemUI)
    {

        ResetDraggedItem();
    }


    private void HandleShowItemActions(DescriptionSkillUI inventoryItemUI)
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

    private void HandleSwap(DescriptionSkillUI inventoryItemUI)
    {
        int index = inventoryUiItems.IndexOf(inventoryItemUI);
        if (index == -1)
        {
            return;
        }
        OnSwapItems?.Invoke(currentlyDraggedItemIndex, index);
        HandleItemSelection(inventoryItemUI);
    }


    public void HandleItemSelection(DescriptionSkillUI inventoryItemUI)
    {
        int index = inventoryUiItems.IndexOf(inventoryItemUI);
        DescriptionSkillUI.Instance.index = index;
        UpgradeSkill.Instance.Skill = inventoryUiItems[index].SkillPlayer;
        UpdateDescription(index);
        if (index == -1)
            return;
        OnDescriptionRequested?.Invoke(index);

    }


    private void HandleBeginDrag(DescriptionSkillUI inventoryItemUI)
    {
        int index = inventoryUiItems.IndexOf(inventoryItemUI);

        if (index == -1)
            return;
        currentlyDraggedItemIndex = index;
        HandleItemSelection(inventoryItemUI);
        OnStartDragging?.Invoke(index);
    }
    public void Hide()
    {
        actionPanel.Toggle(false);
        ResetDraggedItem();
    }
}
