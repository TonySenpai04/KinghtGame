using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [Header("HP")]
   // [SerializeField] protected GameObject FloatingText;
    [SerializeField] private TextMeshProUGUI TextTime;
    public TextMeshProUGUI healthText;
    public HealthBar healthbar;
    public TextMeshProUGUI bottletext;
    [SerializeField] private TextMeshProUGUI Info;
    void Start()
    {
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
        if (HPController.instance.currenthp > HPController.instance.maxhp)
        {
            HPController.instance.currenthp = HPController.instance.maxhp;
        }
        if (HPController.instance.currenthp <= 0)
        {
            HPController.instance.currenthp = 0;
        }
        bottletext.text =HPController.instance. Countbottle + "";
        healthText.text = "HP:" + HPController.instance.currenthp.ToString("N1") + "/" + HPController.instance.maxhp.ToString("N1");
        healthbar.SetMaxHp(HPController.instance.maxhp);
        healthbar.SetHp(HPController.instance.currenthp);

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
}
