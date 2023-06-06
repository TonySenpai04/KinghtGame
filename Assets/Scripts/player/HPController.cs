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
    [SerializeField]private int AddHp;
    [SerializeField] private float HpRecuperate ;
    public int countbottle;
    protected int maxbottle = 99;
   [SerializeField] private InventorySO inventoryData;
    [SerializeField] private GameObject Onrevive;
    public bool isselection;
    [Header("TimeItem")]
    [SerializeField] private bool CanX2;
    [SerializeField] public float CurrentTime;
    [SerializeField] private int Timeitem;
    [SerializeField] public int TimeMinute;
    [SerializeField] public bool Isuse;
    [SerializeField] private int CloneHP;
    [SerializeField] private bool Levelup;
    [Header("UI")]
    [SerializeField] protected GameObject FloatingText;
 
    private void Awake()
    {        instance = this;
        Maxhp = info.HpStart;
        Countbottle = 10;
        CloneHP=Maxhp;
        Levelup = false;
        Onrevive.gameObject.SetActive(false);
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
    public int Addhp()
    {
      //  if (Input.GetKey(KeyCode.O))
      //  {
            AddHp += 100;
      //  }
        return AddHp;
    }
    public void UpdateHP()
    {
         Maxhp+=AddHp;
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.V))
        {
            TakeDamage(10);
        }     
    }
    public  void TakeDamage(int Dmg)
    {
        currenthp-=Dmg;
        if(currenthp < 0)
        {
            currenthp = 0;
        }
        if (FloatingText != null)
        {
            Showfloatingtext(Dmg);
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
    
    void Showfloatingtext(int Dmg)
    {
        var Text = Instantiate(FloatingText, transform.position, Quaternion.identity, transform);
        Text.GetComponent<TextMesh>().text = "-" + Dmg.ToString();
    }

    public void IncreaseHealth(int level)
    {
        CloneHP += Mathf.RoundToInt((CloneHP  * 0.037f) * ((100 - level) * 0.1f));
        Levelup = true;
        if (LevelSystem.mylevel.level == 30)
        {
            CloneHP = info.HpMax;
            Maxhp = CloneHP + Addhp();
        }
        Maxhp = CloneHP + Addhp();
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
