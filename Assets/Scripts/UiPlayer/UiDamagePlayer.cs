using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiDamagePlayer : MonoBehaviour
{
    public static UiDamagePlayer instance;
    public AudioClip AttackSound;
    public TextMeshProUGUI textdmg;
    [SerializeField] private TextMeshProUGUI CritText;
    private void Start()
    {
        instance = this;
      
    }
    private void Update()
    {
        UpdateUI();
    }
    protected void UpdateUI()
    {
        if (AttackFunction.instance.DmgClone > AttackFunction.instance.info.MaxDmg)
        {
            AttackFunction.instance.DmgClone = AttackFunction.instance.info.MaxDmg;
        }
        textdmg.text = "DMG:" + AttackFunction.instance.dmg.ToString("#,##").Replace(',', '.');
        CritText.text = "Crit:" + AttackFunction.instance.Crit + "%";
    }
}
