using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Inventory.UI
{
    public class MouseFollower : MonoBehaviour
    {
        // Start is called before the first frame update

        [SerializeField]
        private Canvas canvas;

        [SerializeField]
        private InventoryUiItem item;

        public void Awake()
        {
            canvas = transform.root.GetComponent<Canvas>();
            item = GetComponentInChildren<InventoryUiItem>();
        }

        public void SetData(Sprite sprite, int quantity)
        {
            item.SetData(sprite, quantity);
        }
        void Update()
        {
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                (RectTransform)canvas.transform,
                Input.mousePosition,
                canvas.worldCamera,
                out position
                    );
            transform.position = canvas.transform.TransformPoint(position);
        }

        public void Toggle(bool val)
        {
        //    Debug.Log($"Item toggled {val}");
            gameObject.SetActive(val);
        }

    }
}