using Inventory.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillPage : Page
{
    public static SkillPage Instance;
    [SerializeField] private DescriptionSkillUI inventoryUiItem;
    public List<DescriptionSkillUI> UiSkills = new List<DescriptionSkillUI>();
    public int SkillPoint = 0;
    public TextMeshProUGUI TxtSkillsPoint;
    public Transform Player;
    public event Action<int> OnDescriptionRequested,
         OnItemActionRequested,
         OnStartDragging;
    public event Action<int, int> OnSwapItems;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        SetSkill();
        SkillsPointUI();
    }
    public void SkillsPointUI()
    {
        TxtSkillsPoint.text = "Skill Point: " + SkillPoint;
    }
    public void SetSkill()
    {
        Player = GameObject.Find("player").transform;
        for (int i = 0; i < UiSkills.Count; i++)
        {
            UiSkills[i].SkillPlayer = Player.GetComponent<AttackFunction>().skillS0[i];
        }
        IntializeInventory();
    }
    internal void UpdateDescription(int itemIndex)
    {

        DeselectAllItems();
        UiSkills[itemIndex].Select();
    }

    internal void ResetAllItems()
    {
        foreach (var item in UiSkills)
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
        actionPanel.transform.position = UiSkills[index].transform.position;
    }
    private void DeselectAllItems()
    {
        foreach (DescriptionSkillUI item in UiSkills)
        {
            item.Deselect();
        }
        actionPanel.Toggle(false);
    }

    public void UpdateData(int itemIndex,
        Sprite itemImage, Sprite background, string description)
    {
        if (UiSkills.Count > itemIndex)
        {
            UiSkills[itemIndex].SetDescription(UiSkills[itemIndex].SkillPlayer);
        }

    }

    public void AddItem()
    {
        DescriptionSkillUI[] items = GetComponentsInChildren<DescriptionSkillUI>();
        UiSkills.AddRange(items);
    }
    public void IntializeInventory()
    {

        
        foreach (var item in UiSkills)
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
        int index = UiSkills.IndexOf(inventoryItemUI);

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
        int index = UiSkills.IndexOf(inventoryItemUI);
        if (index == -1)
        {
            return;
        }
        OnSwapItems?.Invoke(currentlyDraggedItemIndex, index);
        HandleItemSelection(inventoryItemUI);
    }


    public void HandleItemSelection(DescriptionSkillUI inventoryItemUI)
    {
        int index = UiSkills.IndexOf(inventoryItemUI);
        DescriptionSkillUI.Instance.index = index;
        UpgradeSkill.Instance.Skill = UiSkills[index].SkillPlayer;
        UpdateDescription(index);
        if (index == -1)
            return;
        OnDescriptionRequested?.Invoke(index);

    }


    private void HandleBeginDrag(DescriptionSkillUI inventoryItemUI)
    {
        int index = UiSkills.IndexOf(inventoryItemUI);

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
