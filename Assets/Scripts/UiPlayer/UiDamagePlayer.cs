using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiDamagePlayer : MonoBehaviour
{
    public static UiDamagePlayer Instance;
    public TextMeshProUGUI textdmg;
    [SerializeField] private TextMeshProUGUI CritText;
    public TextMeshProUGUI TextTime;
    public float time = 0;
    public Sprite IconItem;
    public UiItemTonic itemTonic;
    public bool IsUse = false;

    private void Start()
    {
        Instance = this;
    }
    private void Update()
    {
        UpdateUI();
        
            if (time > 0 && TextTime != null)
            {
                IsUse = true;
                time -= 1 * Time.deltaTime;
                UpdateUiItemTonic();

             }
    }
    protected void UpdateUI()
    {
        if (AttackFunction.Instance.OriginalDmg > PlayerData.Intance.characterData.MaxDmg)
        {
            AttackFunction.Instance.OriginalDmg = PlayerData.Intance.characterData.MaxDmg;
        }
        textdmg.text = "DMG:" + AttackFunction.Instance.dmg.ToString("#,##").Replace(',', '.');
        CritText.text = "Crit:" + AttackFunction.Instance.Crit + "%";
    }
    public void UpdateUiItemTonic()
    {
        if (time < 60)
        {
            TextTime.text = time.ToString("0") + "s";
        }
        else
        {

            TextTime.text = (time / 60).ToString("0") + "'";
        }
        if (time <= 0)
        {
            time = 0;
            TextTime.text = time.ToString("0");
            TextTime.gameObject.SetActive(true);
            AttackFunction.Instance.dmg = AttackFunction.Instance.OriginalDmg + AttackFunction.Instance.damageAdd;
            AttackFunction.Instance.CanX2 = true;
            AttackFunction.Instance.IsTonic = false;
            IsUse = false;
            Destroy(itemTonic.gameObject);
        }
        else if (time > 0)
        {
            TextTime.gameObject.SetActive(true);
        }
 
    }
}
