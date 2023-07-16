using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeSkill : MonoBehaviour
{
    public static TimeSkill Instance ;
    [Header("TimeSkill")]
    [SerializeField] private float CurrentTime;
    [SerializeField] private float Timeskill;
    [SerializeField] private bool Isuse;
    [SerializeField]
    private SkillS0 skillS0;
    public float Currenttime { get => CurrentTime; set => CurrentTime = value; }
    public bool IsUseSkill { get => Isuse; set => Isuse = value; }
    public float timeskill { get => Timeskill; set => Timeskill = value; }

    private void Start()
    {
        IsUseSkill = true;
        Instance = this;
        Timeskill = skillS0.CooldownTime;
    }

    public void Cooldown()
    {
        CurrentTime -= 1 * Time.deltaTime; 
        if (CurrentTime <= 0)
        {
            
            CurrentTime = 0;
            IsUseSkill = true;
        }
        else if (CurrentTime > 0)
        {
            IsUseSkill = false;
        }

    }

}
