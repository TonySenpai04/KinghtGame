using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiItemTonicPage : MonoBehaviour
{
    public static UiItemTonicPage Instance;
    [SerializeField] private RectTransform contentPanel;
    public UiItemTonic itemTonic;
    public List<UiItemTonic> inventoryUiItems = new List<UiItemTonic>();
   
    private void Awake()
    {
        Instance = this;

    }
    private void Start()
    {
        //IntializeInventory();
    }
    public void IntializeInventory()
    {

        UiItemTonic[] items = GetComponentsInChildren<UiItemTonic>();
        inventoryUiItems.AddRange(items);
        foreach (var item in inventoryUiItems)
        {
            item.transform.SetParent(contentPanel);
            item.gameObject.SetActive(false);

        }
    }

}
