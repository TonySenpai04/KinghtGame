using Inventory.Model;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Pool;

public class ShopMananger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private InventorySO inventoryData;
    public static ShopMananger Instance;
    [SerializeField] public int[,] Items = new int[10, 10];
    //[SerializeField]
    [Header("Price")]
    [SerializeField] private int PriceItem1;
    [SerializeField] private int PriceItem2;
    [SerializeField] private int PriceItem3;
    [SerializeField] private int PriceItem4;
    List<int> ID = new List<int>();
    [SerializeField] private int CountId;
    [SerializeField] private InventoryItem item;

    private void Start()
    {

        Instance = this;
        //ID
        Items[1, 1] = 1;
        Items[1, 2] = 2;
        Items[1, 3] = 3;
        Items[1, 4] = 4;
        Items[1, 5] = 5;
        //Price
        Items[2, 1] = PriceItem1;
        Items[2, 2] = PriceItem2;
        Items[2, 3] = PriceItem3;
        Items[2, 4] = PriceItem4;
        Items[2, 5] = PriceItem4;
    }

  
    public void BuyHp()
    {
        if (Gold_Diamond.instance.Gold >= Items[2,1])
        {
            Gold_Diamond.instance.Gold -= Items[2, 1];
            HPController.instance.Countbottle++;
        }
    }
    public void BuyMp(){
        if (Gold_Diamond.instance.Gold >= Items[2,2])
        {
            Gold_Diamond.instance.Gold -= Items[2,2];
            MPController.instance.Countbottle++;
        }
    }
    public void BuyX2Hp()
    {
        if (Gold_Diamond.instance.Diamond >= Items[2, 3])
        {
            Gold_Diamond.instance.Diamond -= Items[2, 3];
            HPController.instance.ItemHP();
        }
    }
    public void BuyX2Exp()
    {
        if (Gold_Diamond.instance.Diamond >= Items[2, 5])
        {
            Gold_Diamond.instance.Diamond -= Items[2, 5];
            LevelSystem.mylevel.ItemExp();
        }
    }
    public void BuyX2Mp()
    {
        if (Gold_Diamond.instance.Diamond >= Items[2, 4])
        {
            Gold_Diamond.instance.Diamond -= Items[2, 4];
            MPController.instance.ItemMP();
        }
    }

}
