using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public static PlayerUI instance;
    [Header("HP")]
    [SerializeField] private TextMeshProUGUI TextTime;
    public TextMeshProUGUI healthText;
    public HealthBar healthbar;
    public TextMeshProUGUI bottletext;
    [SerializeField] private TextMeshProUGUI Info; 
    [SerializeField] public GameObject FloatingText;
    [SerializeField] public TextMeshProUGUI TextArmor;
    void Start()
    {
        instance = this;
        TextTime.text = "Time remaining:" + HPController.instance.CurrentTime.ToString("0");
        healthbar.SetMaxHp(HPController.instance.maxhp);
        healthbar.SetHp(HPController.instance.currenthp);
        
    }

    // Update is called once per frame
    void Update()
    {
        updateUi();
        TimeHPX2();
    }
    public void updateUi()
    {
        if (HPController.instance.currenthp >= HPController.instance.maxhp)
        {
            HPController.instance.currenthp = HPController.instance.maxhp;
        }
        if (HPController.instance.currenthp <= 0)
        {
            HPController.instance.currenthp = 0;
        }
        bottletext.text =HPController.instance. Countbottle + "";
        healthText.text = "HP:" + HPController.instance.currenthp.ToString("#,##").Replace(',','.') + "/" + HPController.instance.maxhp.ToString("#,##").Replace(',', '.');
        healthbar.SetMaxHp(HPController.instance.maxhp);
        healthbar.SetHp(HPController.instance.currenthp);
        if (HPController.instance.Armor == 0)
        {
            TextArmor.text = "Armor:0";
        }
        else
        {
            TextArmor.text = "Armor:" + HPController.instance.Armor.ToString("#,##").Replace(',', '.');
        }
    }
    public void TimeHPX2()
    {
        if (HPController.instance.CurrentTime < 60 )
        {
            TextTime.text = "Time remaining:" + HPController.instance.CurrentTime.ToString("0") + "s";
        }
        else
        {

            TextTime.text = "Time remaining:" + HPController.instance.TimeMinute.ToString("0") + "'";
        }
        if (HPController.instance.CurrentTime <= 0)
        {
            HPController.instance.CurrentTime = 0;
            TextTime.text = "Time remaining:" + HPController.instance.CurrentTime.ToString("0");
            TextTime.gameObject.SetActive(true);
           // HPController.instance.Isuse = false;
        }
        else if (HPController.instance.CurrentTime > 0)
        {
            TextTime.gameObject.SetActive(true);
        }
        HPController.instance.TimeMinute = (int)(HPController.instance.CurrentTime / 60);
    }
    public void ShowFloatingText(int Dmg)
    {
        var Text = Instantiate(FloatingText, transform.parent.position, Quaternion.identity, transform);
        Text.GetComponent<TextMesh>().text = "-" + Dmg.ToString();
    }
    public void ShowFloatingTextMiss()
    {
        var Text = Instantiate(FloatingText, transform.parent.position, Quaternion.identity, transform);
        Text.GetComponent<TextMesh>().text = "Miss" ;
    }
}
