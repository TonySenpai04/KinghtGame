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
    [SerializeField] private int MaxHP;
    [SerializeField] protected float Currenthp;
    public float currenthp { get => Currenthp; set => Currenthp = value; }
    public int maxHp { get => MaxHP; set => MaxHP = value; }
    public int CurrentBottle { get => currentBottle; set => currentBottle = value; }
    [SerializeField]public int AddHp;
    [SerializeField] private float HpRecuperate ;
    public int currentBottle;
    [SerializeField] private InventorySO inventoryData;
    public int dodgeAttack;
    [SerializeField] public int OriginalHP;
    [Header("Item")]
    [SerializeField] public bool CanX2;
    [SerializeField] public bool IsTonic;
    private void Awake()
    {
        Instance = this;
        
    }
    void Start()
    {
        CanX2 = true;
        IsTonic = false;
        AddHp = 0;
        currenthp = PlayerData.Intance.characterData.CurrentHP;
        MaxHP = PlayerData.Intance.characterData.HpStart;
        CurrentBottle = PlayerData.Intance.characterData.QuantityHpBotte;
        OriginalHP = PlayerData.Intance.characterData.OriginalHp;
        dodgeAttack = PlayerData.Intance.characterData.DogdeAtk;
        AddHp = PlayerData.Intance.characterData.HpAdd;
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
        PlayerData.Intance.characterData.CurrentHP = (int)currenthp;
    }

    public void ItemHP()
    {
        if (UiHpPlayer.Instance.time > 0 )
        {
            IsTonic = true;
            if (CanX2 == true)
            {
                MaxHP = OriginalHP + AddHp;
                MaxHP*= 2;
            }
            CanX2 = false;
        }
    }  
    public void IncreaseHealth(int level)
    {
        OriginalHP += Mathf.RoundToInt((OriginalHP  * 0.037f) * ((100 - level) * 0.1f));
        PlayerData.Intance.characterData.OriginalHp = OriginalHP;
        if (OriginalHP > PlayerData.Intance.characterData.HpMax)
        {

            OriginalHP = PlayerData.Intance.characterData.HpMax;
        }
        MaxHP = OriginalHP + AddHp;
        Currenthp =MaxHP;
        HpRecuperate = MaxHP / 5;
        PlayerData.Intance.characterData.HpStart = maxHp;
    }
    
    public void RecuperateHp()
    {
        if (CurrentBottle > 0)
        {
            HpRecuperate = MaxHP / 5;
            if (HpRecuperate > 500000)
            {
                HpRecuperate = 500000;
            }
            currenthp += HpRecuperate;
            if (currenthp > MaxHP)
            {
                currenthp = MaxHP;
            }
            CurrentBottle--;
            PlayerData.Intance.characterData.QuantityHpBotte = CurrentBottle;
        }
    }

}
