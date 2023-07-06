using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Inventory.Model
{
    public class PickUpSystem : MonoBehaviour
    {
        [SerializeField] private GameObject PanelPickUp;
        [SerializeField]
        private InventorySO inventoryData;
        public TextMeshProUGUI TxtPickUp;
        private void OnTriggerEnter2D(Collider2D collision)
        {
      
            Item item = collision.GetComponent<Item>();
            if (item != null)
            {
                if (item.InventoryItem.Name == "Gold")
                {
                    item.Quantity = Random.Range(5, 20);
                    ShowItemDrop(Color.yellow, "Gold +" + item.Quantity);
                    Gold_Diamond.instance.Gold += item.Quantity;
                    item.DestroyItem();
                }
                else if (item.InventoryItem.Name == "Diamond")
                {
                    item.Quantity = Random.Range(5, 20);
                    ShowItemDrop(Color.blue, "Diamond +" + item.Quantity);
                    Gold_Diamond.instance.Diamond += item.Quantity;
                   item.DestroyItem();
                    
                }
                else
                {
                    item.Quantity = 1;
                    ShowItemDrop(Color.black, "You picked up " + item.Quantity + " " + item.InventoryItem.Name);
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
            TxtPickUp.text = Text;
            TxtPickUp.color = color;
            PanelPickUp.gameObject.SetActive(true);
            StartCoroutine(SetEnabled());
        }
        IEnumerator SetEnabled()
        {
            yield return new WaitForSeconds(3);
            PanelPickUp.gameObject.SetActive(false);
        }
    }
}
