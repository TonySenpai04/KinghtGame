using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ability : MonoBehaviour
{
    public static Ability instance;
    [Header("Skill1")]
    public Image abilityImage1;
    public TextMeshProUGUI abilityText1;
    //public KeyCode ability1Key;
    public float ability1Cooldown ;
    private bool isAbility1Cooldown = false;
    public float currentAbility1Cooldown;
    [Header("Skill2")]
    public Image abilityImage2;
    public TextMeshProUGUI abilityText2;
    //public KeyCode ability1Key;
    public float ability2Cooldown = 8;
    private bool isAbility2Cooldown = false;
    public float currentAbility2Cooldown;
    [Header("Skill3")]
    public Image abilityImage3;
    public TextMeshProUGUI abilityText3;
    //public KeyCode ability1Key;
    public float ability3Cooldown = 12;
    private bool isAbility3Cooldown = false;
    public float currentAbility3Cooldown;
    [Header("Skill4")]
    public Image abilityImage4;
    public TextMeshProUGUI abilityText4;
    //public KeyCode ability1Key;
    public float ability4Cooldown = 12;
    private bool isAbility4Cooldown = false;
    public float currentAbility4Cooldown;

    void Start()
    {
        instance = this;
        abilityImage1.fillAmount = 0;
        abilityImage2.fillAmount = 0;
        abilityImage3.fillAmount = 0;
        abilityImage4.fillAmount = 0;
    }
    void Update()
    {
        Ability1Input();
        Ability2Input();
        Ability3Input();
        Ability4Input();
        ability1Cooldown = Skill.Instance.time[0].timeskill;
        ability2Cooldown = Skill.Instance.time[1].timeskill;
        ability3Cooldown = Skill.Instance.time[2].timeskill;
        ability4Cooldown = Skill.Instance.time[3].timeskill;
        AbilityCooldown(ref currentAbility1Cooldown, ability1Cooldown, ref isAbility1Cooldown, abilityImage1, abilityText1);
        AbilityCooldown(ref currentAbility2Cooldown, ability2Cooldown, ref isAbility2Cooldown, abilityImage2, abilityText2);
        AbilityCooldown(ref currentAbility3Cooldown, ability3Cooldown, ref isAbility3Cooldown, abilityImage3, abilityText3);
        AbilityCooldown(ref currentAbility4Cooldown, ability4Cooldown, ref isAbility4Cooldown, abilityImage4, abilityText4);
    }
    private void Ability1Input()
    {
        if ((InputManager.Instance.IsSkill1) && !isAbility1Cooldown)
        {
            isAbility1Cooldown = true;
            currentAbility1Cooldown = ability1Cooldown;
            ActionbarPage.Instance.UpdateDescription(0);
        }
    }
    private void Ability2Input()
    {
        if ((InputManager.Instance.IsSkill2) && !isAbility2Cooldown)
        {
            isAbility2Cooldown = true;
            currentAbility2Cooldown = ability2Cooldown;
            ActionbarPage.Instance.UpdateDescription(1);
        }
    }
    private void Ability3Input()
    {
        if ((InputManager.Instance.IsSkill3 || ActionbarPage.Instance.IsSkill3Click) && !isAbility3Cooldown)
        {
            isAbility3Cooldown = true;
            currentAbility3Cooldown = ability3Cooldown;
            ActionbarPage.Instance.UpdateDescription(2);
        }
    }
    private void Ability4Input()
    {
        if ((InputManager.Instance.IsSkill4 || ActionbarPage.Instance.IsSkill4Click) && !isAbility4Cooldown)
        {
            isAbility4Cooldown = true;
            currentAbility4Cooldown = ability4Cooldown;
            ActionbarPage.Instance.UpdateDescription(3);
        }
    }
    private void AbilityCooldown(ref float currentCooldown, float maxCooldown, ref bool isCooldown, Image skillImage, TextMeshProUGUI skillText)
    {
        if (isCooldown)
        {
            currentCooldown -= Time.deltaTime;

            if (currentCooldown <= 0f)
            {   
                isCooldown = false;
                currentCooldown = 0f;
                if (skillImage != null)
                {
                    skillImage.fillAmount = 0f;
                }
                if (skillText != null)
                {
                    skillText.text = "";
                }
            }
            else
            {
                if (skillImage != null)
                {
                    skillImage.fillAmount = currentCooldown / maxCooldown;
                }
                if (skillText != null)
                {
                    skillText.text = currentCooldown.ToString("N1");
                }
            }

        }
    }
}
