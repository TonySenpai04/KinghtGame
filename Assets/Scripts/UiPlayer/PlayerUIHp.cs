using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UiHpPlayer : MonoBehaviour
{
    public static UiHpPlayer Instance;
    [Header("HP")]
    [SerializeField] public TextMeshProUGUI TextTime;
    public TextMeshProUGUI healthText;
    public HealthBar healthbar;
    public TextMeshProUGUI bottletext;
    [SerializeField] public GameObject FloatingText;
    public float time=0;
    public Sprite IconItem;
    public UiItemTonic itemTonic;
    public bool IsUse=false;
    
    void Start()
    {
        
        Instance = this;
        healthbar.SetMaxHp(HPController.Instance.maxhp);
        healthbar.SetHp(HPController.Instance.currenthp); 

    }

    // Update is called once per frame
    void Update()
    {
        UpdateUi();
        if (time > 0 && TextTime!=null)
        {
            IsUse = true;
             time -= 1 * Time.deltaTime;
             UpdateUiItemTonic();
        }
       
    }
    public void UpdateUi()
    {
        if (HPController.Instance.currenthp >= HPController.Instance.maxhp)
        {
            HPController.Instance.currenthp = HPController.Instance.maxhp;
        }
        if (HPController.Instance.currenthp <= 0)
        {
            HPController.Instance.currenthp = 0;
        }
        bottletext.text =HPController.Instance. CurrentBottle.ToString();
        healthText.text = "HP:" + HPController.Instance.currenthp.ToString("#,##").Replace(',','.') + "/" + HPController.Instance.maxhp.ToString("#,##").Replace(',', '.');
        healthbar.SetMaxHp(HPController.Instance.maxhp);
        healthbar.SetHp(HPController.Instance.currenthp);
      
    }
    
    public void UpdateUiItemTonic()
    {
        if (time < 60 )
        {
            TextTime.text =  time.ToString("0") + "s";
        }
        else
        {
            TextTime.text = (time/60).ToString("0") + "'";
        }
        if (time <= 0)
        {
            time = 0;
            TextTime.text =  time.ToString("0");
            TextTime.gameObject.SetActive(true);
            HPController.Instance.maxhp = HPController.Instance.OriginalHP + HPController.Instance.AddHp;
            HPController.Instance.CanX2 = true;
            HPController.Instance.IsTonic = false;
            UiItemTonicPage.Instance.inventoryUiItems.Remove(itemTonic);
            IsUse = false;
            Destroy(itemTonic.gameObject); 
        }
        else if (time > 0)
        {
            TextTime.gameObject.SetActive(true);
        }
   
    }
    public void ShowFloatingText(int Dmg)
    {
        var Text = Instantiate(FloatingText, transform.parent.position, Quaternion.identity, transform);
        Text.GetComponent<TextMeshPro>().text = "-" + Dmg.ToString();
    }
    public void ShowFloatingTextMiss()
    {
        var Text = Instantiate(FloatingText, transform.parent.position, Quaternion.identity, transform);
        Text.GetComponent<TextMeshPro>().text = "Miss" ;
    }
}
