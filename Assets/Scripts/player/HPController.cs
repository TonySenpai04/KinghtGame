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
    public static HPController instance;
    [Header("Info")]
    [SerializeField]protected InfoCharacter info;
    [SerializeField] private int Maxhp;
    [SerializeField] protected float Currenthp;
    [SerializeField] private GameObject SkillUi;
    public float currenthp { get => Currenthp; set => Currenthp = value; }
    public int maxhp { get => Maxhp; set => Maxhp = value; }
    public int Countbottle { get => countbottle; set => countbottle = value; }
    [SerializeField]public int AddHp;
    [SerializeField] private float HpRecuperate ;
    public int countbottle;
    protected int maxbottle = 99;
    [SerializeField] private InventorySO inventoryData;
    [SerializeField] private GameObject Onrevive;
    public int dodgeAttack;
    [SerializeField] public int CloneHP;
    [Header("TimeItem")]
    [SerializeField] public bool CanX2;
    [SerializeField] public bool Isuse;
    [SerializeField] private bool Levelup;
    private void Awake()
    {
        instance = this;
        Maxhp = info.HpStart;
        Countbottle = 10;
        CloneHP=Maxhp;
        Levelup = false;
        Onrevive.gameObject.SetActive(false);
  
        dodgeAttack = 0;
    }
    void Start()
    {
        Currenthp = Maxhp;  
        CanX2 = true;
        Isuse = false;
        AddHp = 0;
    }
    void Update()
    {
        Ondead();
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
        if (PlayerUI.instance.FloatingText != null)
        {
          PlayerUI.instance.ShowFloatingText(Bleed);
        }
    }

    public void ItemHP()
    {
        if (PlayerUI.instance.time > 0 )
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
        if (LevelSystem.instance.level == 30)
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
        if (Countbottle > 0)
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
            Countbottle--;
        }
    }
    public void Ondead()
    {
        if (currenthp == 0)
        {
            Onrevive. gameObject.SetActive(true);
            SkillUi.SetActive(false);
        }  
    }
    public void Revival()
    {
        currenthp += maxhp;
        MPController.instance.Currentmp += MPController.instance.Maxmp;
        Onrevive.gameObject.SetActive(false);
        AnimationPlayer.instance.Animator.SetBool("Idle", true);
        AnimationPlayer.instance.IsDead = false;
        Gold_Diamond.instance.Diamond -= 1;
        SkillUi.SetActive(true);
    }
}
