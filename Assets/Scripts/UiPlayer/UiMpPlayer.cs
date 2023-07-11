using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiMpPlayer: MonoBehaviour
{
    public static UiMpPlayer Instance;
    [Header("MP")]
    [SerializeField] public TextMeshProUGUI TextTime;
    public TextMeshProUGUI mpText;
    public MpBar mpBar;
    public TextMeshProUGUI bottletext;
    [SerializeField] private TextMeshProUGUI Info;
    public float time = 0;
    public Sprite IconItem;
    public UiItemTonic itemTonic;
    public bool IsUse = false;
  
    void Start()
    {
        Instance = this;
        mpBar.SetMaxMp(MPController.Instance.Maxmp);
        mpBar.SetMp(MPController.Instance.Currentmp);
    }

    // Update is called once per frame
    void Update()
    {
        updateUi();
        if (time > 0 && TextTime!=null )
        {
            IsUse=true;
            time -= 1 * Time.deltaTime;
            UpdateUiItemTonic();
        }
       
    }
    public void updateUi()
    {
        if (MPController.Instance.Currentmp > MPController.Instance.Maxmp)
        {
            MPController.Instance.Currentmp = MPController.Instance.Maxmp;
        }
        if (MPController.Instance.Currentmp <= 0)
        {
            MPController.Instance.Currentmp = 0;
        }
        bottletext.text = MPController.Instance.CurrentBottle + "";
        mpText.text = "MP:" + MPController.Instance.Currentmp.ToString("#,##").Replace(',', '.') + "/" + MPController.Instance.Maxmp.ToString("#,##").Replace(',', '.');
        mpBar.SetMaxMp(MPController.Instance.Maxmp);
        mpBar.SetMp(MPController.Instance.Currentmp);

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
            MPController.Instance.Maxmp = MPController.Instance.OriginalMp + MPController.Instance.addMp;
            MPController.Instance.CanX2 = true;
            MPController.Instance.IsTonic = false;
            IsUse = false;
            Destroy(itemTonic.gameObject);
        }
        else if (time > 0)
        {
            TextTime.gameObject.SetActive(true);
        }
   
    }
}
