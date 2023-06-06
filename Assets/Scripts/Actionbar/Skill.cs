using System;
using System.Collections;
using System.Collections.Generic;
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
        update();
    }
    private void Update()
    {
        
    }
    private void update()
    {     
          
            if ( time[0].Isuse1==false)
            {
                AnimationPlayer.instance.IsSkill1 = false;
                time[0].CountDown();
                
            }
           else if (time[0].Isuse1 == true)
            {
                AnimationPlayer.instance.IsSkill1 = true;
            }
           
            if (time[1].Isuse1 == false)
            {
                AnimationPlayer.instance.isSkill2 = false;
                time[1].CountDown();
                
            }
           else if (time[1].Isuse1 == true)
            {
                AnimationPlayer.instance.isSkill2 = true;

            }
        if (LevelSystem.mylevel.level >= 3)
        {
            skill[1].SetActive(true);
            textIndex[1].text = "2";
        }
    }

}
