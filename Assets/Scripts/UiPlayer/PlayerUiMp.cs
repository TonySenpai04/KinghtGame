using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class PlayerUIMp : MonoBehaviour
{
    [Header("MP")]
    // [SerializeField] protected GameObject FloatingText;
    [SerializeField] private TextMeshProUGUI TextTime;
    public TextMeshProUGUI mpText;
    public MpBar mpBar;
    public TextMeshProUGUI bottletext;
    [SerializeField] private TextMeshProUGUI Info;
    void Start()
    {
        TextTime.text = "Time remaining:" + MPController.instance.CurrentTime.ToString("0");
        mpBar.SetMaxMp(MPController.instance.Maxmp);
        mpBar.SetMp(MPController.instance.Currentmp);
    }

    // Update is called once per frame
    void Update()
    {
        updateUi();
        TimeHPX2();
    }
    public void updateUi()
    {
        if (MPController.instance.Currentmp > MPController.instance.Maxmp)
        {
            MPController.instance.Currentmp = MPController.instance.Maxmp;
        }
        if (MPController.instance.Currentmp <= 0)
        {
            MPController.instance.Currentmp = 0;
        }
        bottletext.text = MPController.instance.Countbottle + "";
        mpText.text = "MP:" + MPController.instance.Currentmp.ToString("#,##").Replace(',', '.') + "/" + MPController.instance.Maxmp.ToString("#,##").Replace(',', '.');
        mpBar.SetMaxMp(MPController.instance.Maxmp);
        mpBar.SetMp(MPController.instance.Currentmp);

    }
    public void TimeHPX2()
    {
        if (MPController.instance.CurrentTime < 60)
        {
            TextTime.text = "Time remaining:" + MPController.instance.CurrentTime.ToString("0") + "s";
        }
        else
        {

            TextTime.text = "Time remaining:" + MPController.instance.TimeMinute.ToString("0") + "'";
        }
        if (MPController.instance.CurrentTime <= 0)
        {
            HPController.instance.CurrentTime = 0;
            TextTime.text = "Time remaining:" + MPController.instance.CurrentTime.ToString("0");
            TextTime.gameObject.SetActive(true);
            // HPController.instance.Isuse = false;
        }
        else if (MPController.instance.CurrentTime > 0)
        {
            TextTime.gameObject.SetActive(true);
        }
        MPController.instance.TimeMinute = (int)(MPController.instance.CurrentTime / 60);
    }
}
