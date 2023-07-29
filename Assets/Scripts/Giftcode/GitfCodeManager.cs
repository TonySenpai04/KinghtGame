using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Windows;

public class GitfCodeManager : MonoBehaviour
{
    public Dictionary<string, int[]> GiftCode;
    public TMP_InputField Input;
    public GameObject PanelNotification;
    void Start()
    {
        GiftCode = new Dictionary<string, int[]>
        {
            { "tonyvippro", new int[] { 1000000000, 10000 } }
        };
    }

    public void CheckCode()
    {
        string inputCode=Input.text;
        if (Input != null)
        {
            if (GiftCode.ContainsKey(inputCode)) 
            {
               
                Gold_Diamond.instance.Gold += GiftCode[inputCode][0];
                Gold_Diamond.instance.Diamond += GiftCode[inputCode][1];
                PlayerData.Intance.characterData.Gold = Gold_Diamond.instance.Gold;
                PlayerData.Intance.characterData.Diamond = Gold_Diamond.instance.Diamond;
                PanelNotification.GetComponentInChildren<TextMeshProUGUI>().text = "Enter the gift code successfully";
                PanelNotification.gameObject.SetActive(true);
                Invoke("SetEnabled", 2f);

            }
            else
            {
                PanelNotification.GetComponentInChildren<TextMeshProUGUI>().text = "Wrong gift code";
                PanelNotification.gameObject.SetActive(true);
                Invoke("SetEnabled", 2f);

            }
        }
    }
    public void SetEnabled()
    {
        PanelNotification.SetActive(false);
        Input.text = "";
    }

}
