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
        [SerializeField] public Image Background;
        private void Awake()
        {
            ResetDescription();
        }
        public void ResetDescription()
        {

            Background.gameObject.SetActive(false);
            this.Title.text = "";
            this.Description.text = "";
        }
        public void SetDescription(Sprite sprite, string itemname, string itemDescription,Sprite background)
        {
            this.Background.gameObject.SetActive(true);
            this.ItemImage.sprite = sprite;
            this.Title.text = itemname;
            this.Background.sprite = background;
            this.Description.text = itemDescription;

        }
    }
}
