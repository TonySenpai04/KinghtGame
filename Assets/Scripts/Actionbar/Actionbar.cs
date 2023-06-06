using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Actionbar : MonoBehaviour
{
    [SerializeField] public Image ItemImage;
    private void Awake()
    {
        ResetDescription();
    }
    public void ResetDescription()
    {

        ItemImage.gameObject.SetActive(false);
    }
    public void SetDescription(Sprite sprite)
    {
        this.ItemImage.gameObject.SetActive(true);
        this.ItemImage.sprite = sprite;
    }

}
