using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoSkill : MonoBehaviour
{
    public Skill SkillTime;
    [Header("Skill1")]
    [SerializeField] private TextMeshProUGUI Skill1;
    [SerializeField] private TextMeshProUGUI TimeSkill1;
    [SerializeField]
    private float TimeCountdownSkill1;
    [Header("Skill2")]
    // [SerializeField] private TextMeshProUGUI levelSkill1;
   [SerializeField] private TextMeshProUGUI Skill2;
    [SerializeField] private TextMeshProUGUI TimeSkill2;
    [SerializeField]
    private float TimeCountdownSkill2;
    //  [SerializeField] private TextMeshProUGUI levelSkill2;
    private void Update()
    {
        UpdateUi();
    }
   protected void UpdateUi()
    {
        Skill1.text = (AttackFunction.instance.DmgAddSkill1 * 100).ToString() + "%";
        SkillTime.time[0].timeskill = TimeCountdownSkill1;
        TimeSkill1.text = SkillTime.time[0].timeskill.ToString();
        SkillTime.time[1].timeskill = TimeCountdownSkill2;
        Skill2.text = (AttackFunction.instance.DmgAddSkill2 * 100).ToString() + "%";
        TimeSkill2.text = SkillTime.time[1].timeskill.ToString();
    }
}
