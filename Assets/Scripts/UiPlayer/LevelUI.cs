using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    public static LevelUI instance;
    public Slider exslider;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI XpText;
   // [SerializeField] public TextMeshProUGUI TextTime;
    private void Start()
    {
        instance = this;
        levelText.text = "Level: " + LevelSystem.instance.level;
        XpText.text = Mathf.Round(LevelSystem.instance.currentXp) + "/" + Mathf.Round(LevelSystem.instance.nextLevelXp);
        XpText.text = LevelSystem.instance.currentXp + "/" + LevelSystem.instance.nextLevelXp;
    }
    public void UPdateUI()
    {
        levelText.text = "Level: " + LevelSystem.instance.level;
        XpText.text = Mathf.Round(LevelSystem.instance.currentXp) + "/" + Mathf.Round(LevelSystem.instance.nextLevelXp);
        SetMaxExp(LevelSystem.instance.nextLevelXp);
        SetExp(LevelSystem.instance.currentXp);
        XpText.text = LevelSystem.instance. currentXp + "/" + LevelSystem.instance. nextLevelXp;
    }
    public void SetMaxExp(float maxxp)
    {
        exslider.maxValue = maxxp;
    }
    public void SetExp(float currentxp)
    {
        exslider.value = currentxp;
    }
    
}
