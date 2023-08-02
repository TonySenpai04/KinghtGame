using Inventory.Model;
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
        
    }
    private void Reset()
    {
        GameObject[] Pet= GetComponentsInChildren<GameObject>();
        Pets.AddRange( Pet );
    }

}
