using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace Inventory.UI
{
    public class InventoryDescription : MonoBehaviour
    {
        [SerializeField] public Image ItemImage;
        [SerializeField] private TextMeshProUGUI Title;
        [SerializeField] private TextMeshProUGUI Description;
        private void Awake()
        {
            ResetDescription();
        }
        public void ResetDescription()
        {

            ItemImage.gameObject.SetActive(false);
            this.Title.text = "";
            this.Description.text = "";
        }
        public void SetDescription(Sprite sprite, string itemname, string itemDescription)
        {
            this.ItemImage.gameObject.SetActive(true);
            this.ItemImage.sprite = sprite;
            this.Title.text = itemname;
            this.Description.text = itemDescription;

        }
    }
}
