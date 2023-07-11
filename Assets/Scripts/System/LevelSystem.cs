
using System.Collections;
using TMPro;

using Unity.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
   
    public static LevelSystem Instance;
    [SerializeField]  public int level;
    [SerializeField] protected float maxLevel=30;
    [SerializeField] public float currentXp;
    [SerializeField] public int nextLevelXp = 100;
    public int Exp;
    [Header("Multipliers")]
    [Range(1f, 400f)]
    [SerializeField] private float additionMultiplier;
    [Range(2f, 4f)]
    [SerializeField] private float powerMultiplier = 20f;
    [Range(7f, 14f)]
    [SerializeField] private float divisionMultiplier = 7f;
   
    [Header("Item")]
    [SerializeField] public bool CanX2;
    [SerializeField] public bool IsTonic;
    //Timers
    private float lerpTimer;
    private float delayTimer;

    public bool IsUse { get => IsTonic; set => IsTonic = value; }

    private void Awake()
    {
        Instance = this;
        level = 1;
        CanX2 = true;
        IsUse = false;
    }
    
    void Start()
    {
        currentXp=0;
        level = 1;
        nextLevelXp = CalculateNextLevelXp();
    }
    void Update()
    {
        
        if (level != maxLevel)
        {
            if (currentXp >= nextLevelXp)
            {
                LevelUp();
            }
        }
        else
        {
            LevelUI.Instance. XpText.text = "MAX";
        }
    }
    public void ItemExp()
    {
        if (LevelUI.Instance.time > 0)
        {
            IsUse = true;
            if (CanX2 == true)
            {
                HpEnemy.Instance.expDmg *= 2;
            }

            CanX2 = false;
        }
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
        AttackFunction.Instance.IncreaseAtk(level);
        currentXp = Mathf.Round(currentXp-nextLevelXp);
        nextLevelXp = CalculateNextLevelXp();
        level = Mathf.Clamp(level,0, 50);
        LevelUI.Instance.SetExp(currentXp);
        LevelUI.Instance. levelText.text = "Level:" + level;
        GetComponent<HPController>().IncreaseHealth(level);
        GetComponent<MPController>().IncreaseMP(level);
        AudioSource.PlayClipAtPoint(AudioPlayer.instance.levelUpSound, transform.position);
        SkillPage.Instance.SkillPoint+=1;
        SkillPage.Instance.SkillsPointUI();
        if (HPController.Instance.IsTonic == true)
        {
            HPController.Instance.maxhp=(HPController.Instance.OriginalHP+ HPController.Instance.AddHp)*2;
        }
        if (MPController.Instance.IsTonic == true)
        {
            MPController.Instance.Maxmp = (MPController.Instance.OriginalMp + MPController.Instance.addMp) * 2;
        }
        if (AttackFunction.Instance.IsTonic == true)
        {
            AttackFunction.Instance.dmg = (AttackFunction.Instance.OriginalDmg + AttackFunction.Instance.damageAdd) * 2;
        }
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
