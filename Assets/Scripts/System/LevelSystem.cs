
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
    [SerializeField] public bool Isuse;
    //Timers
    private float lerpTimer;
    private float delayTimer;

    public bool IsUse { get => Isuse; set => Isuse = value; }

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
       // levelText.text = "Level: " + level;
        level = 1;
       // XpText.text = Mathf.Round(currentXp) + "/" + Mathf.Round(nextLevelXp);
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
        //CurrentTime += 600;
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
