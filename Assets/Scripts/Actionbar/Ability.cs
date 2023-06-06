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

    void Start()
    {
        instance = this;
        abilityImage1.fillAmount = 0;
        abilityImage2.fillAmount = 0;
    }
    void Update()
    {
        Ability1Input();
        Ability2Input();
        ability1Cooldown = Skill.Instance.time[0].timeskill;
        ability2Cooldown = Skill.Instance.time[1].timeskill;
        AbilityCooldown(ref currentAbility1Cooldown, ability1Cooldown, ref isAbility1Cooldown, abilityImage1, abilityText1);
        AbilityCooldown(ref currentAbility2Cooldown, ability2Cooldown, ref isAbility2Cooldown, abilityImage2, abilityText2);
    }
    private void Ability1Input()
    {
        if (InputManager.Instance.isSkill1 && !isAbility1Cooldown)
        {
            isAbility1Cooldown = true;
            currentAbility1Cooldown = ability1Cooldown;
        }
    }
    private void Ability2Input()
    {
        if (InputManager.Instance.isSkill2 && !isAbility2Cooldown)
        {
            isAbility2Cooldown = true;
            currentAbility2Cooldown = ability2Cooldown;
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
