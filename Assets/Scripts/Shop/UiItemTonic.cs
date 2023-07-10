using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiItemTonic : MonoBehaviour
{
    public static UiItemTonic Instance;
    public Image Icon;
    public TextMeshProUGUI Txt;
    [SerializeField] protected bool empty = true;
    private void Start()
    {
        Instance = this;
    }
    public void ResetData()
    {
        gameObject.SetActive(false);
        this.Txt.text = "";
        empty = true;

    }
    public void SetData(Sprite sprite)
    {

         this.Icon.sprite = sprite;
         empty = false;
    }
}
