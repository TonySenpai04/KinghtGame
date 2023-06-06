using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    // Start is called before the first frame update
    public int ItemID;
    public TextMeshProUGUI TextPrice;
    [SerializeField] private GameObject Shopmanager;
    public static ButtonInfo instance;
   
    private void Start()
    {
      
        instance=this;
        TextPrice.text = Shopmanager.GetComponent<ShopMananger>().Items[2,ItemID].ToString();
    }
    // Update is called once per frame
    void Update()
    {
        TextPrice.text =  Shopmanager.GetComponent<ShopMananger>().Items[2, ItemID].ToString();
    }
}
