using Inventory.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiItem : MonoBehaviour
{
    [SerializeField] protected Image Image;
    [SerializeField] public ItemActionPanel Transformbtn;
    [SerializeField] public bool empty = true;
    [SerializeField] public int index;
    [SerializeField] protected Image BackGround;
    [SerializeField] public Image borderImage;
}
