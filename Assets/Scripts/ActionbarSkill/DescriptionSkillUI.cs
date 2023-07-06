using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionSkillUI : MonoBehaviour
{
    public SkillS0 SkillPlayer;
    public Image ICon;
    public TextMeshProUGUI TxtDescription;
    public float CooldownTime;
    public int Level;
    public float DmgAdd;
    private void Start()
    {
        SetDescription();
    }
    public void SetDescription()
    {
        ICon.sprite = SkillPlayer.Icon;
        DmgAdd = SkillPlayer.DmgAdd;
        CooldownTime = SkillPlayer.CooldownTime;
        Level=SkillPlayer.Level;
        TxtDescription.text = "Inflict damage " +DmgAdd*100+"%"+ "\nRequired level:" +
           Level + "\nCooldown Time:" + CooldownTime;
    }
}
