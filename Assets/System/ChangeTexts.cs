using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTexts : MonoBehaviour
{
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value / 1 == 0)
        {
            Debug.Log("0");
            text1.text = slider.value.ToString("F1");
            text2.text = slider.value.ToString("F1");
        }
        else
        {
            Debug.Log("1");
            text1.text = slider.value.ToString("F0");
            text2.text = slider.value.ToString("F0");
        }
    }
}
