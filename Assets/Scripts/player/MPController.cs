using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MPController : MonoBehaviour
{
    public static MPController Instance;
    [Header("Info")]
    [SerializeField] InfoCharacter info;
    [SerializeField] private int MaxMp;
    [SerializeField] private int CurrentMp;
    [SerializeField] protected float MPRecuperate;
    [SerializeField] private int currentBottle;
    [SerializeField] private int maxbottle = 99;
    [SerializeField] public int CloneMp;
    [SerializeField] public int addMp;
    public int Currentmp { get => CurrentMp; set => CurrentMp = value; }
    public int Maxmp { get => MaxMp; set => MaxMp = value; }
    public int CurrentBottle { get => currentBottle; set => currentBottle = value; }
    [Header("TimeItem")]
    [SerializeField] public bool Isuse;
    [SerializeField] public bool CanX2;
    [SerializeField] private bool Levelup;


  
    private void Awake()
    {
        Instance = this;
        MaxMp = info.MpStart; 
        CurrentBottle = 10;
        CloneMp = MaxMp;
        Levelup = false;
    }
  
        // Start is called before the first frame update
    void Start()
    {
        Instance= this;
        CurrentMp = MaxMp;
        CanX2 = true;
        Isuse = false;
        
     }

    public void ItemMP()
    {
            if(UiMpPlayer.Instance.time>0)
            {
            Isuse = true;
            if (CanX2 == true )
            {
                Maxmp *= 2;
            }
            CanX2 = false;
        }
    }
    public void MpAttack(int mpAttack)
    {
        CurrentMp -= mpAttack;
    }
    public int AddMP()
    {
        
        return addMp;
    }
    public void  UpdateMp()
    {
        MaxMp += addMp;
    }
    public void IncreaseMP(int level)
    {
        CloneMp += Mathf.RoundToInt((CloneMp * 0.037f) * ((100 - level) * 0.1f));
        Levelup = true;
        if (LevelSystem.Instance.level == 30)
        {
                CloneMp = info.MaxMp;
                MaxMp = CloneMp + addMp;   
        }
        MaxMp = CloneMp+ addMp;
        CurrentMp = MaxMp;
        MPRecuperate = MaxMp / 5;
    }
    protected void RecuperateMp()
    {
        if (CurrentBottle > 0)
        {
            MPRecuperate = MaxMp / 5;
            if (MPRecuperate > 500000)
            {
                MPRecuperate = 500000;
            }

            CurrentMp +=(int)  MPRecuperate;
            if (CurrentMp > MaxMp)
            {
                CurrentMp = MaxMp;
            }
            CurrentBottle--;
        }
    }
}
