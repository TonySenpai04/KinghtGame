using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MPController : MonoBehaviour
{
    public static MPController instance;
    [Header("Info")]
    [SerializeField] InfoCharacter info;
    [SerializeField] private int MaxMp;
    [SerializeField] private int CurrentMp;
    [SerializeField] protected float MPRecuperate;
    [SerializeField] private int countbottle;
    [SerializeField] private int maxbottle = 99;
    [SerializeField] private bool CanX2;
    public int Currentmp { get => CurrentMp; set => CurrentMp = value; }
    public int Maxmp { get => MaxMp; set => MaxMp = value; }
    public int Countbottle { get => countbottle; set => countbottle = value; }
    [Header("TimeItem")]
    [SerializeField] public float CurrentTime;
    [SerializeField] private int Timeitem;
    [SerializeField] public int TimeMinute;
    [SerializeField] public bool Isuse;
    [SerializeField] private int mpclone;
    [SerializeField] private int addmp;
    [SerializeField] private bool Levelup;
    [SerializeField] private int timeHouse;


  
    private void Awake()
    {
        instance = this;
        MaxMp = info.MpStart; 
        Countbottle = 10;
        mpclone = MaxMp;
        Levelup = false;
    }
  
        // Start is called before the first frame update
    void Start()
    {
        instance= this;
        CurrentMp = MaxMp;
        CanX2 = true;
        Timeitem = 0;
        CurrentTime = Timeitem;
        TimeMinute = 0;
        Isuse = false;
        
     }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            MaxMp += 100;
        }
        MPRecuperate = MaxMp / 5;
        if (Isuse == true)
        {
            CountDown();
        }
        AddMP();
      
       
    }
    public void CountDown()
    {
        CurrentTime -= 1 * Time.deltaTime;
        if (CurrentTime <= 0)
        {
            Isuse = false;
        }
    }
    public void ItemMP()
    {
           CurrentTime += 600; 
            if(CurrentTime>0)
            {
            Isuse = true;
            if (CanX2 == true )
            {
                Maxmp *= 2;
                StartCoroutine(SetMp());
            }
            CanX2 = false;
        }
    }
    IEnumerator SetMp()
    {
        yield return new WaitForSeconds(CurrentTime);
        if (LevelSystem.mylevel.level == 30 && CanX2 == false)
        {
            Maxmp = mpclone+addmp;
        }
        else
        {
            Maxmp /= 2;
        }
        CanX2 = true;
        CurrentTime = Timeitem;
    }

    public void MpAttack(int mpAttack)
    {
        CurrentMp -= mpAttack;
    }
    public int AddMP()
    {
        if (Input.GetKey(KeyCode.O))
        {
            addmp += 100;
        }
        return addmp;
    }
    public void  MPReal()
    {
        Maxmp += AddMP();
    }
    public void IncreaseMP(int level)
    {
        mpclone += Mathf.RoundToInt((mpclone * 0.037f) * ((100 - level) * 0.1f));
        Levelup = true;
        if (LevelSystem.mylevel.level == 30)
        {
                mpclone = info.MaxMp;
                MaxMp = mpclone + AddMP();   
        }
        MaxMp = mpclone+AddMP();
        CurrentMp = MaxMp;
    }
    protected void RecuperateMp()
    {
        if (Countbottle > 0)
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
            Countbottle--;
        }
    }
}
