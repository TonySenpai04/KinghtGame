using Inventory.Model;
using Inventory.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActionbarPage : MonoBehaviour
{
    [SerializeField] private RectTransform contentPanel;
    public List<ActionbarUi> actionList=new List<ActionbarUi>();
    private int currentlyDraggedItemIndex = -1;
    public event Action<int> OnDescriptionRequested,
            OnItemActionRequested,
            OnStartDragging;
    public event Action<int, int> OnSwapItems;
    public Transform Player;


    private void Start()
    {
        AddSkill();
        Player = GameObject.Find("player").transform;
        actionList[0].Skill = Player.GetComponent<AttackFunction>().skillS0[0];
        actionList[1].Skill = Player.GetComponent<AttackFunction>().skillS0[1];
        actionList[2].Skill = Player.GetComponent<AttackFunction>().skillS0[2];
        IntializeInventory();
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
    private void Update()
    {
        Player = GameObject.Find("player").transform;
        actionList[0].Skill = Player.GetComponent<AttackFunction>().skillS0[0];
        actionList[1].Skill = Player.GetComponent<AttackFunction>().skillS0[1];
        actionList[2].Skill = Player.GetComponent<AttackFunction>().skillS0[2];
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
