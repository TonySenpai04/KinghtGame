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
        healthbar.SetMaxHp(HPController.instance.maxhp);
        healthbar.SetHp(HPController.instance.currenthp); 

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
        if (HPController.instance.currenthp >= HPController.instance.maxhp)
        {
            HPController.instance.currenthp = HPController.instance.maxhp;
        }
        if (HPController.instance.currenthp <= 0)
        {
            HPController.instance.currenthp = 0;
        }
        bottletext.text =HPController.instance. Countbottle + "";
        healthText.text = "HP:" + HPController.instance.currenthp.ToString("#,##").Replace(',','.') + "/" + HPController.instance.maxhp.ToString("#,##").Replace(',', '.');
        healthbar.SetMaxHp(HPController.instance.maxhp);
        healthbar.SetHp(HPController.instance.currenthp);
      
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
            HPController.instance.maxhp = HPController.instance.CloneHP + HPController.instance.AddHp;
            HPController.instance.CanX2 = true;
            HPController.instance.Isuse = false;
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
        Text.GetComponent<TextMesh>().text = "-" + Dmg.ToString();
    }
    public void ShowFloatingTextMiss()
    {
        var Text = Instantiate(FloatingText, transform.parent.position, Quaternion.identity, transform);
        Text.GetComponent<TextMesh>().text = "Miss" ;
    }
}
