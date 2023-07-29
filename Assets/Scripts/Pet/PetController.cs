using Inventory.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetController : MonoBehaviour
{
    public static PetController instance;
    public List<GameObject> Pets;
    public InventoryPageUsingItem usingItem;
    private void Start()
    {
        instance = this;
        for (int i = 0; i < Pets.Count; i++)
        {
            if (usingItem.InventorySO.inventoryItems[6].item != null)
            {
                if (Pets[i].name == usingItem.InventorySO.inventoryItems[6].item.name)
                {
                    Pets[i].SetActive(true);
                }
                else
                {
                    Pets[i].SetActive(false);
                }
            }
            else
            {
                Pets[i].SetActive(false);
            }
        }
        
    }
    private void Reset()
    {
        GameObject[] Pet= GetComponentsInChildren<GameObject>();
        Pets.AddRange( Pet );
    }
    public void SetPet()
    {
       
    }
}
