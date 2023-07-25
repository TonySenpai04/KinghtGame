using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gold_DiamondUI : MonoBehaviour
{
    [Header("Coin_Diamond" + "")]
    [SerializeField]
    protected TextMeshProUGUI TextGold;
    [SerializeField] protected TextMeshProUGUI TextDiamond;
    void Update()
    {
        UpdateUI();
    }
    public void UpdateUI()
    {
        TextGold.text = Gold_Diamond.instance.Gold.ToString("#,##").Replace(',', '.') ;
        TextDiamond.text = Gold_Diamond.instance.Diamond .ToString("#,##").Replace(',', '.');

    }
}
