using Inventory.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSkill : ItemAction
{
    public static new UpgradeSkill Instance;
    [SerializeField] public SkillS0 Skill;

    public new void Start()
    {
        Instance = this;
 
    }
    public override void AddButon(string name, Action onClickAction)
    {
        GameObject button = Instantiate(buttonPrefab, transform);
        button.GetComponent<Button>().onClick.AddListener(() => onClickAction());
        button.GetComponentInChildren<TMPro.TMP_Text>().text = name;

    }
    public override void AddAction()
    {
        SkillPage.Instance.actionPanel.AddButon("Upgrade", () => Upgrade(this.Skill), () => ResetData());
        SkillPage.Instance.actionPanel.AddButon("Close", () => ResetData(), () => ResetData());

    }

    private void ResetData()
    {
        SkillPage.Instance.ResetSelection();
    }

    public void Upgrade(SkillS0 skill)
    {
        if (skill.LevelSkill <= skill.MaxLevelSkill && SkillPage.Instance.SkillPoint >= 1)
        {
            skill.LevelSkill= skill.LevelSkill++;
            skill.DmgAdd= skill.DmgAdd += skill.IncreasesWithLevel;
            DataSkills.Intance.SkillData[DescriptionSkillUI.Instance.index]= skill;
            SkillPage.Instance.SkillPoint -= 1;
            SkillPage.Instance.SkillsPointUI();
            SkillPage.Instance.IntializeInventory();
            
        }
    }
}
