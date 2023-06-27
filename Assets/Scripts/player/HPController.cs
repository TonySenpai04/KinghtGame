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
    public bool isselection;
    public int dodgeAttack;
    public int Armor;
    [Header("TimeItem")]
    [SerializeField] private bool CanX2;
    [SerializeField] public float CurrentTime;
    [SerializeField] private int Timeitem;
    [SerializeField] public int TimeMinute;
    [SerializeField] public bool Isuse;
    [SerializeField] private int CloneHP;
    [SerializeField] private bool Levelup;
   
 
    private void Awake()
    {   instance = this;
        Maxhp = info.HpStart;
        Countbottle = 10;
        CloneHP=Maxhp;
        Levelup = false;
        Onrevive.gameObject.SetActive(false);
        Armor = 0;
        dodgeAttack = 0;
    }
    void Start()
    {
        Timeitem = 0;
        CurrentTime = Timeitem;
        Currenthp = Maxhp;  
        CanX2 = true;
        Isuse = false;
        AddHp = 0;
        isselection = false;
    }
    void Update()
    {
        HpRecuperate = Maxhp / 5;
        if (Isuse == true)
        {
            CountDown();
        }
        Ondead();
    }
   
    public void CountDown()
    {
        CurrentTime -= 1 * Time.deltaTime;
        if(CurrentTime <= 0)
        {
            Isuse = false;
        } 
    }
    public void UpdateHP()
    {
         Maxhp+=AddHp;
    }
    public  void TakeDamage(int Dmg)
    {
        int Bleed = (Dmg - (Armor / 4));
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
        CurrentTime += 600;
        //  CloneHP+=AddHp;
        if (CurrentTime > 0 )
        {
            Isuse = true;
            if (CanX2 == true)
            {
                Maxhp *= 2;
                StartCoroutine(SetHp());
            }
            CanX2 = false;
        }
    }  
    public void IncreaseHealth(int level)
    {
        CloneHP += Mathf.RoundToInt((CloneHP  * 0.037f) * ((100 - level) * 0.1f));
        Levelup = true;
        if (LevelSystem.mylevel.level == 30)
        {
            CloneHP = info.HpMax;
            Maxhp = CloneHP + AddHp;
        }
        Maxhp = CloneHP + AddHp;
        Currenthp =Maxhp;
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
    IEnumerator SetHp()
    {
        yield return new WaitForSeconds(CurrentTime);
        if (LevelSystem.mylevel.level == 30 && CanX2 == false)
        {
            Maxhp = CloneHP + AddHp;
        }
        else
        {
            Maxhp /= 2;
        }
        CanX2=true;
        CurrentTime = Timeitem;

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
