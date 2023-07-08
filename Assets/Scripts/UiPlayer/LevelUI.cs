using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    public static LevelUI Instance;
    public Slider exslider;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI XpText;
    public TextMeshProUGUI TextTime;
    public float time = 0;
    public Sprite IconItem;
    public UiItemTonic itemTonic;
    public bool IsUse = false;
    private void Start()
    {
        Instance = this;
        levelText.text = "Level: " + LevelSystem.Instance.level;
        XpText.text = Mathf.Round(LevelSystem.Instance.currentXp) + "/" + Mathf.Round(LevelSystem.Instance.nextLevelXp);
        XpText.text = LevelSystem.Instance.currentXp + "/" + LevelSystem.Instance.nextLevelXp;
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
    public void UPdateUI()
    {
        levelText.text = "Level: " + LevelSystem.Instance.level;
        XpText.text = Mathf.Round(LevelSystem.Instance.currentXp) + "/" + Mathf.Round(LevelSystem.Instance.nextLevelXp);
        SetMaxExp(LevelSystem.Instance.nextLevelXp);
        SetExp(LevelSystem.Instance.currentXp);
        XpText.text = LevelSystem.Instance. currentXp + "/" + LevelSystem.Instance. nextLevelXp;
    }
    public void SetMaxExp(float maxxp)
    {
        exslider.maxValue = maxxp;
    }
    public void SetExp(float currentxp)
    {
        exslider.value = currentxp;
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
            LevelSystem.Instance.CanX2 = true;
            LevelSystem.Instance.Isuse = false;
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
