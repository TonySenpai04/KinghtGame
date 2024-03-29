using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MPController : MonoBehaviour
{
    public static MPController Instance;
    [Header("Info")]
    [SerializeField] private int MaxMp;
    [SerializeField] private int CurrentMp;
    [SerializeField] protected float MPRecuperate;
    [SerializeField] private int currentBottle;
    [SerializeField] public int OriginalMp;
    [SerializeField] public int addMp;
    public int Currentmp { get => CurrentMp; set => CurrentMp = value; }
    public int Maxmp { get => MaxMp; set => MaxMp = value; }
    public int CurrentBottle { get => currentBottle; set => currentBottle = value; }
    [Header("TimeItem")]
    [SerializeField] public bool IsTonic;
    [SerializeField] public bool CanX2;


  
    private void Awake()
    {
        Instance = this;  
    }
  
    void Start()
    {
        MaxMp = PlayerData.Intance.characterData.MpStart;
        CurrentBottle = PlayerData.Intance.characterData.QuantityMPBotte;
        OriginalMp = PlayerData.Intance.characterData.OriginalMp;
        CurrentMp = PlayerData.Intance.characterData.CurrentMP;
        CanX2 = true;
        IsTonic = false;
        addMp = PlayerData.Intance.characterData.MpAdd;
     }
    public void ItemMP()
    {
            if(UiMpPlayer.Instance.time>0)
            {
            IsTonic = true;
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
        PlayerData.Intance.characterData.CurrentMP = Currentmp;
    }
    public void IncreaseMP(int level)
    {
        OriginalMp += Mathf.RoundToInt((OriginalMp * 0.037f) * ((100 - level) * 0.1f));
        PlayerData.Intance.characterData.OriginalMp = OriginalMp;
        if (OriginalMp > PlayerData.Intance.characterData.MaxMp)
        {
               OriginalMp= PlayerData.Intance.characterData.MaxMp;
        }
        MaxMp = OriginalMp+ addMp;
        CurrentMp = MaxMp;
        MPRecuperate = MaxMp / 5;
        PlayerData.Intance.characterData .MpStart = MaxMp;
    }
    public void RecuperateMp()
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
            PlayerData.Intance.characterData.QuantityMPBotte = CurrentBottle;
        }
    }
}
