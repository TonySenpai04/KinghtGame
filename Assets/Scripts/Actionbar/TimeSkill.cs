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
    public float Currenttime { get => CurrentTime; set => CurrentTime = value; }
    public bool Isuse1 { get => Isuse; set => Isuse = value; }
    public float timeskill { get => Timeskill; set => Timeskill = value; }

    private void Start()
    {
        Isuse1 = true;
        Instance = this;
    }

    public void CountDown()
    {
        CurrentTime -= 1 * Time.deltaTime; 
        if (CurrentTime <= 0)
        {
            
            CurrentTime = 0;
            Isuse1 = true;
        }
        else if (CurrentTime > 0)
        {
            Isuse1 = false;
        }

    }

}
