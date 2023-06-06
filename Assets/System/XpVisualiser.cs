
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class XpVisualiser : MonoBehaviour
{
    public int maxLevel;
    [Range(1f, 300f)]
    public float additionMultiplier;
    [Range(2f, 4f)]
    public float powerMultiplier = 20f;
    [Range(7f, 14f)]
    public float divisionMultiplier = 7f;
    public Slider slider1;
    public Slider slider2;
    public Slider slider3;
    public RectTransform panel;
   
    private int lastMaxLevel;
    private float lastAdditionMultiplier;
    private float lastPowerMultiplier;
    private float lastDivisionMultiplier;
    private Canvas canvas;

    private List<int> xpValues = new List<int>();
    private List<GameObject> bars = new List<GameObject>();
    private List<GameObject> levelTexts = new List<GameObject>();
    private List<GameObject> XpTexts = new List<GameObject>();
    private List<GameObject> sideTexts = new List<GameObject>();
    private List<GameObject> blackBars = new List<GameObject>();
    private float fontSize;

  //  public GameObject details;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        panel.sizeDelta = new Vector2(Screen.width * 0.9f, Screen.height * 0.70f);
        panel.transform.position = new Vector2(Screen.width * 0.535f, Screen.height * 0.58f);
        fontSize = 25f;
        SetupGraph();
        SetupDetails();
    }

    // Update is called once per frame
    void Update()
    {
        additionMultiplier = slider1.value;
        powerMultiplier = slider2.value;
        divisionMultiplier = slider3.value;
       lastAdditionMultiplier = CheckValueChanged(lastAdditionMultiplier, additionMultiplier);
       lastPowerMultiplier = CheckValueChanged(lastPowerMultiplier, powerMultiplier);
       lastDivisionMultiplier = CheckValueChanged(lastDivisionMultiplier, divisionMultiplier);
       lastMaxLevel = CheckValueChanged(lastMaxLevel, maxLevel);
    }

    private void GetXpValues()
    {
        xpValues.Clear();
        int level = 1;
        int fp = 0;
        for (int levelCycle = 1; levelCycle <= level; levelCycle++)
        {
            fp += (int)Mathf.Floor(levelCycle + additionMultiplier * Mathf.Pow(powerMultiplier, levelCycle / divisionMultiplier));
            if (level < maxLevel)
                level++;

            int sp = fp / 4;
            xpValues.Add(sp);
        }
    }
    public void SetupGraph()
    {
        ClearGraph();
        GetXpValues();
        for (int i = 0; i < maxLevel; i++)
        {
            GameObject barGO = new GameObject();
            GameObject barText = new GameObject();
            GameObject xpText = new GameObject();
            barGO.transform.parent = panel.transform;
            barText.transform.parent = canvas.transform;
            xpText.transform.parent = canvas.transform;
            barGO.name = "Bar" + i;
            barText.name = "Text" + i;
            RectTransform barTransform = barGO.AddComponent<RectTransform>();
            TextMeshProUGUI barTextMesh = barText.AddComponent<TextMeshProUGUI>();
            TextMeshProUGUI XpTextMesh = xpText.AddComponent<TextMeshProUGUI>();
            Image barImage = barGO.AddComponent<Image>();
            barTextMesh.fontSize = fontSize;
            bars.Add(barGO);
            levelTexts.Add(barText);
            XpTexts.Add(xpText);
            barImage.color = new Color(0.2f,0.2f,0.2f,1);
            float fillAmount = (panel.sizeDelta.y * xpValues[i]) / xpValues[xpValues.Count - 1]; //Mathf.Lerp(0, panel.sizeDelta.y, xpValues[i] / panel.sizeDelta.y);
            barTransform.sizeDelta = new Vector2(panel.sizeDelta.x/ maxLevel -10f, fillAmount);
            barTransform.anchorMin = new Vector2(0.5f, 0);
            barTransform.anchorMax = new Vector2(0.5f, 0);
            barTransform.pivot = new Vector2(0.5f, 0f);
            barTransform.position = new Vector2((panel.transform.position.x - panel.sizeDelta.x*0.5f)+ (barTransform.sizeDelta.x * 0.5f) + 25 + i * ((panel.sizeDelta.x - 25) / maxLevel),
                panel.transform.position.y - panel.sizeDelta.y *0.5f);
            barText.transform.position = new Vector2(barTransform.position.x, barTransform.position.y-20f);
            barTextMesh.alignment = TextAlignmentOptions.Center;
            barTextMesh.text = (i + 1).ToString();
            xpText.transform.position = new Vector2(barTransform.position.x + (barTransform.sizeDelta.x*0.5f), barTransform.position.y + barTransform.sizeDelta.y + 20);
            XpTextMesh.alignment = TextAlignmentOptions.Center;
            xpText.transform.rotation = Quaternion.Euler(0, 0, 80f);
            XpTextMesh.text = xpValues[i].ToString();
            XpTextMesh.fontSize = fontSize;
        }

        for (int i = XpTexts.Count-1; i >= 1; i--)
        {
            XpTexts[i].transform.SetAsFirstSibling();
        }
    
        for (int i = bars.Count-1; i >= 1; i--)
        {
            bars[i].transform.SetAsFirstSibling();
        }
        panel.transform.SetAsFirstSibling();
    }
    private void ClearGraph() 
    {
        for (int i = 0; i < blackBars.Count; i++)
        {
            Destroy(blackBars[i]);
        }
        for (int i = 0; i < levelTexts.Count; i++)
        {
            Destroy(levelTexts[i]);
        }
        for (int i = 0; i < bars.Count; i++)
        {
            Destroy(levelTexts[i]);
            Destroy(bars[i]);

        }
        for (int i = 0; i < XpTexts.Count; i++)
        {
            Destroy(XpTexts[i]);
        }
        for (int i = 0; i < sideTexts.Count; i++)
        {
            Destroy(sideTexts[i]);
        }
        blackBars.Clear();
        bars.Clear();
        sideTexts.Clear();
        XpTexts.Clear();
        levelTexts.Clear();
        }


    private void SetupDetails() 
    {
        for (int i = 1; i < 9; i++)
        {
            GameObject sideText = new GameObject();
            sideTexts.Add(sideText);
            GameObject bar = new GameObject();
            blackBars.Add(bar);
            bar.transform.parent = panel.transform;
            sideText.transform.parent = panel.transform;
            bar.name = "BlackBar";
            Image image = bar.AddComponent<Image>();
            TextMeshProUGUI sideTextMesh = sideText.AddComponent<TextMeshProUGUI>();
      
            RectTransform barTransform = bar.GetComponent<RectTransform>();
            image.color = Color.black;
            if (i == 4 || i == 8) 
            barTransform.sizeDelta = new Vector2(panel.sizeDelta.x, 6);
                    else
            barTransform.sizeDelta = new Vector2(panel.sizeDelta.x, 2);
            sideTextMesh.text = (xpValues[xpValues.Count - 1] * 0.125f * i).ToString();
            barTransform.position = new Vector2(panel.transform.position.x, (panel.transform.position.y - panel.sizeDelta.y*0.5f)+ panel.sizeDelta.y * (0.125f * i));
            sideText.transform.position = new Vector2((panel.transform.position.x - panel.sizeDelta.x*0.5f)-10,  barTransform.position.y);
            bar.transform.SetAsFirstSibling();
            sideTextMesh.fontSize = 25f;
        }

    }
    public void IncreaseTextSize() 
    {
        fontSize++;
        for (int i = 0; i < levelTexts.Count; i++)
        {
            levelTexts[i].GetComponent<TextMeshProUGUI>().fontSize = fontSize;
        }
        for (int i = 0; i < sideTexts.Count; i++)
        {
            sideTexts[i].GetComponent<TextMeshProUGUI>().fontSize = fontSize;
        }
        for (int i = 0; i < XpTexts.Count; i++)
        {
            XpTexts[i].GetComponent<TextMeshProUGUI>().fontSize = fontSize;
        }
    }
    public void DecreaseTextSize()
    {
        fontSize--;
        for (int i = 0; i < levelTexts.Count; i++)
        {
            levelTexts[i].GetComponent<TextMeshProUGUI>().fontSize = fontSize;
        }
        for (int i = 0; i < sideTexts.Count; i++)
        {
            sideTexts[i].GetComponent<TextMeshProUGUI>().fontSize = fontSize;
        }
        for (int i = 0; i < XpTexts.Count; i++)
        {
            XpTexts[i].GetComponent<TextMeshProUGUI>().fontSize = fontSize;
        }
    }
    private float CheckValueChanged(float lastVal, float newVal)
    {
        if (lastVal != newVal)
        {
            lastVal = newVal;
            SetupGraph();
            SetupDetails();
        }
        return newVal;
    }
    private int CheckValueChanged(int lastVal, int newVal)
    {
        if (lastVal != newVal)
        {
            lastVal = newVal;
            SetupGraph();
            SetupDetails();
        }
        return newVal;
    }
}
