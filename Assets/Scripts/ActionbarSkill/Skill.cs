using System;
using TMPro;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public static Skill Instance;
    public GameObject[] skill;
    public TextMeshProUGUI[] textIndex;
    public event Action<Skill> OnItemDropOn, OnItemBeginDrap, OnItemEndDrap, OnRightMouseBtnClick, OnItemClicked;
    public TimeSkill[] time;

    private void Start()
    {
       
        Instance = this;
        time=GetComponentsInChildren<TimeSkill>();
        skill = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            skill[i] = transform.GetChild(i).gameObject;
        }
        foreach (GameObject character in skill)
        {
            character.SetActive(false);
        }
        if (skill[0])
        {
            skill[0].SetActive(true);
            textIndex[0].text = "1";

        }
        for(int i=0;i< time.Length-1; i++)
        {
            time[i] = skill[i].GetComponent<TimeSkill>();
        }
    }
    private void FixedUpdate()
    {
        UpdateSkill();
    }
    private void Update()
    {
        
    }
    private void UpdateSkill()
    {

        CooldownSkill1(0);
        CooldownSkill2(1);
        CooldownSkill3(2);
        SetSkill(3, 1, "2");
        SetSkill(5, 2, "3");
    }
    public void SetSkill(int level,int index,string description)
    {
        if (LevelSystem.Instance.level >= level)
        {
            skill[index].SetActive(true);
            textIndex[index].text = description;
        }
    }
    public void CooldownSkill1(int index)
    {
       
        if (time[index].Isuse1 == false)
        {
            AnimationPlayer.instance.IsSkill1 = false;
            time[index].Cooldown();

        }
        else if (time[index].Isuse1 == true)
        {
            AnimationPlayer.instance.IsSkill1 = true;
        }
    }
    public void CooldownSkill2(int index)
    {

        if (time[index].Isuse1 == false)
        {
            AnimationPlayer.instance.isSkill2 = false;
            time[index].Cooldown();

        }
        else if (time[index].Isuse1 == true)
        {
            AnimationPlayer.instance.isSkill2 = true;
        }
    }
    public void CooldownSkill3(int index)
    {

        if (time[index].Isuse1 == false)
        {
            AnimationPlayer.instance.isSkill3 = false;
            time[index].Cooldown();

        }
        else if (time[index].Isuse1 == true)
        {
            AnimationPlayer.instance.isSkill3 = true;
        }
    }

}
