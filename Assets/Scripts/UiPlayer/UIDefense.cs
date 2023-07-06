using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIDefense : MonoBehaviour
{
    public static UIDefense Instance;
    public TextMeshProUGUI txtDefense;
    private void Start()
    {
        Instance = this;
        txtDefense.text = "Defense:" + 0;
    }
    public void UpdateUI()
    {
        txtDefense.text ="Defense:"+ DefencePlayer.Instance.Defense.ToString();
    }
}
