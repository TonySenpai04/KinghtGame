using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.Model
{
    public class PickUpSystem : MonoBehaviour
    {
        [SerializeField] private GameObject FloatingText;
        [SerializeField]
        private InventorySO inventoryData;
        private void OnTriggerEnter2D(Collider2D collision)
        {
      
            Item item = collision.GetComponent<Item>();
            if (item != null)
            {
                if (item.InventoryItem.Name == "Gold")
                {
                    item.Quantity = Random.Range(5, 20);
                    ShowItemDrop(Color.yellow, "+" + item.Quantity);
                    Gold_Diamond.instance.Gold += item.Quantity;
                    item.DestroyItem();
                }
                else if (item.InventoryItem.Name == "Diamond")
                {
                    item.Quantity = Random.Range(5, 20);
                    ShowItemDrop(Color.blue, "+" + item.Quantity);
                    Gold_Diamond.instance.Diamond += item.Quantity;
                   item.DestroyItem();
                    
                }
                else
                {
                    item.Quantity = 1;
                    ShowItemDrop(Color.white, "You picked up " + item.Quantity + " " + item.InventoryItem.Name);
                    int reminder = inventoryData.AddItem(item.InventoryItem, item.Quantity); 
                    if (reminder == 0)
                        item.DestroyItem();
                    else
                        item.Quantity = reminder;
                }
            }
        }
        void ShowItemDrop(Color color,string Text)
        {
            var TextGold = Instantiate(FloatingText, transform.position, Quaternion.identity, transform);
            TextGold.GetComponent<TextMesh>().text = Text;
            TextGold.GetComponent<TextMesh>().color = color;
        }
    }
}
