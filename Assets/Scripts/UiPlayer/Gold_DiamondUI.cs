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
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }
    public void UpdateUI()
    {
        TextGold.text = Gold_Diamond.instance.Gold+"";
        TextDiamond.text = Gold_Diamond.instance.Diamond + "";

    }
}
