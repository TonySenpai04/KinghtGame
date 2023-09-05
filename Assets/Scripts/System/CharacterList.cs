using Inventory;
using Inventory.UI;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CharacterList : MonoBehaviour
{
    public List<GameObject> Character;
    public GameObject PannelSkillAction;
    public GameObject PannelSkillDescription;
    public List<Sprite> Avata;
    public Image AvataCharacter;
    public InventoryPage InventoryPage;
    public GameObject pannelRevival;
    public InventoryPageUsingItem InventoryPageUsingItem;
    public Button HpBtn;
    public Button MpBtn;
    private void Awake()
    {
        pannelRevival.SetActive(false); 
    }
    private void Start()
    {
        string selectedCharacter = PlayerPrefs.GetString("SelectedCharacter");
        for (int i=0; i<Character.Count; i++)
        {
            if (Character[i].name == selectedCharacter)
            {
                Character[i].SetActive(true);
                AvataCharacter.sprite = Avata[i];
                HpBtn.onClick.AddListener(Character[i].GetComponentInChildren<HPController>().RecuperateHp);
                MpBtn.onClick.AddListener(Character[i].GetComponentInChildren<MPController>().RecuperateMp);
            }
            else
            {
                Character[i].SetActive(false);
            }
        }
        PannelSkillAction.GetComponent<ActionbarPage>().SetSkill();
        PannelSkillDescription.GetComponent<SkillPage>().SetSkill();
        InventoryPage.SetInventoryData();
        InventoryPageUsingItem.SetInventoryData();
       
    }

    private void Reset()
    {
       for(int i=0;i<transform.childCount;i++)
        {
            Character.Add(transform.GetChild(i).gameObject);
        }

    }
}
