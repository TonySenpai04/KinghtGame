using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class PlayerUIMp : MonoBehaviour
{
    public static PlayerUIMp Instance;
    [Header("MP")]
    // [SerializeField] protected GameObject FloatingText;
    [SerializeField] private TextMeshProUGUI TextTime;
    public TextMeshProUGUI mpText;
    public MpBar mpBar;
    public TextMeshProUGUI bottletext;
    [SerializeField] private TextMeshProUGUI Info;
    public float time = 0;
    void Start()
    {
        Instance = this;
        TextTime.text = time.ToString("0");
        mpBar.SetMaxMp(MPController.instance.Maxmp);
        mpBar.SetMp(MPController.instance.Currentmp);
    }

    // Update is called once per frame
    void Update()
    {
        updateUi();
        if (time > 0)
        {
            time -= 1 * Time.deltaTime;
            UiTimeX2Mp();
        }
       
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
    public void UiTimeX2Mp()
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
            MPController.instance.Maxmp = MPController.instance.CloneMp + MPController.instance.addMp;
            MPController.instance.CanX2 = true;
            MPController.instance.Isuse = false;
        }
        else if (time > 0)
        {
            TextTime.gameObject.SetActive(true);
        }
   ;
    }
}
