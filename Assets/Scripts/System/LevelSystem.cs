
using System.Collections;
using TMPro;

using Unity.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
   
    public static LevelSystem mylevel;
    [SerializeField]  public int level;
    [SerializeField] protected float maxLevel=30;
    [SerializeField] protected float currentXp;
    [SerializeField] protected int nextLevelXp = 100;
    public int Exp;
    [Header("Multipliers")]
    [Range(1f, 400f)]
    [SerializeField] private float additionMultiplier;
    [Range(2f, 4f)]
    [SerializeField] private float powerMultiplier = 20f;
    [Range(7f, 14f)]
    [SerializeField] private float divisionMultiplier = 7f;
    [Header("UI")]
    public Slider exslider;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI XpText;
    [SerializeField] private TextMeshProUGUI TextTime;
    [SerializeField] private TextMeshProUGUI Info;
    [Header("Item")]
    [SerializeField] private bool CanX2;
    [SerializeField] private float CurrentTime;
    [SerializeField] private int Timeitem;
    [SerializeField] private int TimeMinute;
    [SerializeField] private bool Isuse;


    //Audio  
    [Header("Audio")]
    public AudioClip levelUpSound;
    private AudioSource source;
    //Timers
    private float lerpTimer;
    private float delayTimer;

    public bool IsUse { get => Isuse; set => Isuse = value; }

    private void Awake()
    {
        mylevel = this;
        level = 1;
        TextTime.text = "Time remaining:" + CurrentTime.ToString("0");
        CanX2 = true;
        IsUse = false;
    }
    
    void Start()
    {
        setMaxExp(nextLevelXp);
        SetExp(currentXp);
        currentXp=0;
        Info.text = "X2 Exp In 10p";
        levelText.text = "Level: " + level;
        level = 1;
        XpText.text = Mathf.Round(currentXp) + "/" + Mathf.Round(nextLevelXp);
        nextLevelXp = CalculateNextLevelXp();
        source = GetComponent<AudioSource>();
    }
    void Update()
    {
        
        if (IsUse == true)
        {
            CountDown();
        }
        UpdateXpUI();
        if (level != maxLevel)
        {
            if (currentXp >= nextLevelXp)
            {
                LevelUp();
            }
        }
        else
        {
            XpText.text = "MAX";
        }
    }
    public void ItemExp()
    {
        CurrentTime += 600;
        if (CurrentTime > 0)
        {
            IsUse = true;
            if (CanX2 == true)
            {
                HpEnemy.Instance.expDmg *= 2;
                StartCoroutine(Setexp());
            }

            CanX2 = false;
        }
    }
    public void CountDown()
    {
        CurrentTime -= 1 * Time.deltaTime;
        if (CurrentTime < 60)
        {
            TextTime.text = "Time remaining:" + CurrentTime.ToString("0") + "s";
        }
        else
        {
            TextTime.text = "Time remaining:" + TimeMinute.ToString("0") + "'";
        }
        if (CurrentTime <= 0)
        {
            CurrentTime = 0;
            TextTime.gameObject.SetActive(true);
            IsUse = false;
        }
        else if (CurrentTime > 0)
        {
            TextTime.gameObject.SetActive(true);
        }
        TimeMinute = (int)(CurrentTime / 60);
    }
    IEnumerator Setexp()
    {
        yield return new WaitForSeconds(CurrentTime);
        HpEnemy.Instance.expDmg /= 2;
        CanX2 = true;
        CurrentTime = Timeitem;

    }

    private void setMaxExp(float maxxp)
    {
        exslider.maxValue = maxxp;
    }
    private void SetExp(float currentxp)
    {
        exslider.value = currentxp;
    }
    private void UpdateXpUI()
    { 
        setMaxExp(nextLevelXp);
        SetExp(currentXp);
        XpText.text = currentXp + "/" + nextLevelXp;
    }
    
    public void GainExperienceFlatRate(int xpGained)
    {
       
            currentXp += xpGained;
            lerpTimer = 0f;
            delayTimer = 0f;
    }
    
    public void GainExperienceScalable(float xpGained, int passedLevel)
    {
        if (passedLevel < level)
        {
            float multiplier = 1 + (level - passedLevel) * 0.1f;
            currentXp += Mathf.Round(xpGained*multiplier);

        }
        else
        {
            currentXp += xpGained;

        }
        if (level == maxLevel)
        {
            currentXp += 0;
        }

        lerpTimer = 0f;
        delayTimer = 0f;

    }
    public void LevelUp() 
    {
        
        level += 1;
        AttackFunction.instance.IncreaseAtk(level);
        currentXp = Mathf.Round(currentXp-nextLevelXp);
        nextLevelXp = CalculateNextLevelXp();
        level = Mathf.Clamp(level,0, 50);
        SetExp(currentXp);
        levelText.text = "Level:" + level;
        GetComponent<HPController>().IncreaseHealth(level);
        GetComponent<MPController>().IncreaseMP(level);
        AudioSource.PlayClipAtPoint(levelUpSound, transform.position);

    }
    private void DisplayAccrueAmount() 
    {
        
    }
    private int CalculateNextLevelXp() 
    {
        int solveForRequiredXp = 0;
        for (int levelCycle = 1; levelCycle <= level; levelCycle++)
        {
            solveForRequiredXp += (int)Mathf.Floor(levelCycle + additionMultiplier * Mathf.Pow(powerMultiplier, levelCycle / divisionMultiplier));
        }
        return solveForRequiredXp / 4;
    }
}
