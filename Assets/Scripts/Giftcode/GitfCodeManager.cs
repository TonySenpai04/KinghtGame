using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
                StartCoroutine(SetEnabled());

            }
        }
    }
    public IEnumerator SetEnabled()
    {
        yield return new WaitForSeconds(2);
        PanelNotification.SetActive(false);
    }

}
