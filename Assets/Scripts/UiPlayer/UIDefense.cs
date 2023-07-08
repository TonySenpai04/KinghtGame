using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIDefense : MonoBehaviour
{
    public static UIDefense Instance;
    public TextMeshProUGUI txtDefense;
    public TextMeshProUGUI TextTime;
    public float time = 0;
    public Sprite IconItem;
    public UiItemTonic itemTonic;
    public bool IsUse = false;
    private void Start()
    {
        Instance = this;
        txtDefense.text = "Defense:" + 0;
    }
    private void Update()
    {
        if (time > 0 && TextTime != null)
        {
            IsUse = true;
            time -= 1 * Time.deltaTime;
            UpdateUiItemTonic();
        }
    }
    public void UpdateUI()
    {
        txtDefense.text ="Defense:"+ DefencePlayer.Instance.Defense.ToString();
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
            DefencePlayer.Instance.Defense = DefencePlayer.Instance.DefenseClone;
            DefencePlayer.Instance.CanX2 = true;
            DefencePlayer.Instance.Isuse = false;
            IsUse = false;
            Destroy(itemTonic.gameObject);
        }
        else if (time > 0)
        {
            TextTime.gameObject.SetActive(true);
        }
  ;
    }
}
