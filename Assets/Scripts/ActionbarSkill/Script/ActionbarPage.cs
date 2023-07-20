using System;
using System.Collections.Generic;
using UnityEngine;

public class ActionbarPage : Page
{
    public static ActionbarPage Instance ;
    public List<ActionbarUi> actionList=new List<ActionbarUi>();
    public Transform Player;
    public event Action<int> OnDescriptionRequested,
         OnItemActionRequested,
         OnStartDragging;
    public event Action<int, int> OnSwapItems;
    public bool IsSkill1Click;
    public bool IsSkill2Click;
    public bool IsSkill3Click;
    public bool IsSkill4Click;
    private void Awake()
    {
        Instance=this;
        AddSkill();
        SetSkill();
    }
    private void Start()
    {
        DeselectAllItems(); 
        foreach (GameObject character in Skill.Instance. skill)
        {
            character.SetActive(false);
        }
        if (Skill.Instance.skill[0])
        {
            Skill.Instance. skill[0].SetActive(true);
            Skill.Instance.textIndex[0].text = "1";
        }
    }
    public void SetSkill()
    {
        Player = GameObject.Find("player").transform;
        for (int i = 0; i < actionList.Count; i++)
        {
            actionList[i].Skill = Player.GetComponent<AttackFunction>().skillS0[i];
        }
        IntializeInventory();
    }
    public void AddSkill()
    {
        ActionbarUi[] skill = GetComponentsInChildren<ActionbarUi>();
        this.actionList.AddRange(skill);
    }
    public void Componets()
    {
        if (this.actionList.Count > 0) return;
        ActionbarUi[] skill= GetComponentsInChildren<ActionbarUi>();
        this.actionList.AddRange(skill);
    }
 
    public void IntializeInventory()
    {
        foreach (var item in actionList)
        {
            item.SetData();
            item.transform.SetParent(contentPanel);
            item.OnItemClicked += HandleItemSelection;
            item.OnItemBeginDrap += HandleBeginDrag;
            item.OnItemDropOn += HandleSwap;
            item.OnItemEndDrap += HandleEndDrag;
            item.OnRightMouseBtnClick += HandleShowItemActions;
        }

    }
    internal void UpdateDescription(int itemIndex)
    {
        DeselectAllItems();
        actionList[itemIndex].Select();
    }
    public void ResetSelection()
    {
        DeselectAllItems();

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
    public void DeselectAllItems()
    {
        foreach (ActionbarUi item in actionList)
        {
            item.Deselect();
        }
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
        UpdateDescription(index);
        switch (index)
        {
            case 0:
                IsSkill1Click = true;
                break;
            case 1:
                IsSkill2Click = true;

                break;
            case 2:
                IsSkill3Click = true;
                break;
            case 3:
                IsSkill4Click = true;
                break;
            default:
                break;
        }
   
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
