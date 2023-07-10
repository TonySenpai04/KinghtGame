using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.PlayerLoop;
using Unity.VisualScripting;
using Inventory.Model;
using Inventory;

public class HPController : MonoBehaviour
{
    public static HPController Instance;
    [Header("Info")]
    [SerializeField]protected InfoCharacter info;
    [SerializeField] private int Maxhp;
    [SerializeField] protected float Currenthp;
    public float currenthp { get => Currenthp; set => Currenthp = value; }
    public int maxhp { get => Maxhp; set => Maxhp = value; }
    public int CurrentBottle { get => currentBottle; set => currentBottle = value; }
    [SerializeField]public int AddHp;
    [SerializeField] private float HpRecuperate ;
    public int currentBottle;
    protected int maxbottle = 99;
    [SerializeField] private InventorySO inventoryData;
    public int dodgeAttack;
    [SerializeField] public int CloneHP;
    [Header("Item")]
    [SerializeField] public bool CanX2;
    [SerializeField] public bool Isuse;
    [SerializeField] private bool Levelup;
    private void Awake()
    {
        Instance = this;
        Maxhp = info.HpStart;
        CurrentBottle = 10;
        CloneHP=Maxhp;
        Levelup = false;
        dodgeAttack = 0;
    }
    void Start()
    {
        Currenthp = Maxhp;  
        CanX2 = true;
        Isuse = false;
        AddHp = 0;
    }
    public void UpdateHP()
    {
         Maxhp+=AddHp;
    }
    public  void TakeDamage(int Dmg)
    {
        int Bleed = (Dmg - (DefencePlayer.Instance.Defense / 4));
        if (Bleed <= 0)
        {
            Bleed = 1;
        }
        currenthp -=Bleed;
        if(currenthp < 0)
        {
            currenthp = 0;
        }
        if (UiHpPlayer.Instance.FloatingText != null)
        {
          UiHpPlayer.Instance.ShowFloatingText(Bleed);
        }
    }

    public void ItemHP()
    {
        if (UiHpPlayer.Instance.time > 0 )
        {
            Isuse = true;
            if (CanX2 == true)
            {
                Maxhp = CloneHP + AddHp;
                Maxhp*= 2;
            }
            CanX2 = false;
        }
    }  
    public void IncreaseHealth(int level)
    {
        CloneHP += Mathf.RoundToInt((CloneHP  * 0.037f) * ((100 - level) * 0.1f));
        Levelup = true;
        if (LevelSystem.Instance.level == 30)
        {
            CloneHP = info.HpMax;
            Maxhp = CloneHP + AddHp;
        }
        Maxhp = CloneHP + AddHp;
        Currenthp =Maxhp;
        HpRecuperate = Maxhp / 5;
    }
    
    public void RecuperateHp()
    {
        if (CurrentBottle > 0)
        {
            HpRecuperate = Maxhp / 5;
            if (HpRecuperate > 500000)
            {
                HpRecuperate = 500000;
            }
            currenthp += HpRecuperate;
            if (currenthp > Maxhp)
            {
                currenthp = Maxhp;
            }
            CurrentBottle--;
        }
    }
    
    
}
