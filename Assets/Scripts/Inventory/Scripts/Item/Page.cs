using Inventory.Model;
using Inventory.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page : MonoBehaviour
{
    [SerializeField] public RectTransform contentPanel;
    [SerializeField] public InventoryDescription inventoryDescription;
    public InventorySO InventorySO;
    public MouseFollower mouseFollower;
    [SerializeField]
    public ItemActionPanel actionPanel;
    public int currentlyDraggedItemIndex = -1;
    

}
