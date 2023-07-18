using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Inventory.Model
{
    public class PickUpSystem : MonoBehaviour
    {
        public static PickUpSystem Instance;    
        [SerializeField] private GameObject PanelPickUp;
        [SerializeField]
   
        public TextMeshProUGUI TxtPickUp;
        public int GoldDrop;
        public int DiamondDrop;
        private void Start()
        {
           Instance = this;
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Item item = collision.GetComponent<Item>();
            if (item != null)
            {
                if (item.InventoryItem.Name == "Gold")
                {
                    item.Quantity = GoldDrop;
                    ShowItemDrop(Color.yellow, "Gold +" + item.Quantity);
                    Gold_Diamond.instance.Gold += item.Quantity;
                    PlayerData.Intance.characterData.Gold =(int) Gold_Diamond.instance.Gold;
                    item.DestroyItem();
                }
                else if (item.InventoryItem.Name == "Diamond")
                {
                    item.Quantity = DiamondDrop;
                    ShowItemDrop(Color.blue, "Diamond +" + item.Quantity);
                    Gold_Diamond.instance.Diamond += item.Quantity;
                    PlayerData.Intance.characterData.Diamond = (int) Gold_Diamond.instance.Diamond;
                    item.DestroyItem();
                    
                }
                else
                {
                    item.Quantity = 1;
                    ShowItemDrop(Color.black, "You picked up " + item.Quantity + " " + item.InventoryItem.Name);
                    int reminder =SaveGameManager.instance.Inventory.AddItem(item.InventoryItem, item.Quantity); 
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
