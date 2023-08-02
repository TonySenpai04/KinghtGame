using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Healthsystem : MonoBehaviour
{
    // Start is called before the first frame update
  [SerializeField]  private float maxhp;
  [SerializeField]  protected float currenthp;
    public healthbarenemy healthbar;
     public TextMeshProUGUI healthText;
    public float Currenthp { get => currenthp; set => currenthp = value; }
    public float Maxhp { get => maxhp; set => maxhp = value; }
   
    
    private void Awake()
    {

        Maxhp = 200;
       
        healthbar.setmaxh(Maxhp);
    }
    // Start is called before the first frame update
    void Start()
    {

        currenthp = Maxhp;
        healthbar.sethp(currenthp);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();

    }

    protected void TakeDamage(int Dmg)
    {
        currenthp -= Dmg;
        healthbar.sethp(currenthp);
        if (currenthp < 0)
        {
            currenthp = 0;
        }
    }
    protected void UpdateUI()
    {
       
        healthText.text = currenthp + "/" + Maxhp;
    }
    public void IncreaseHealth(int level)
    {
        Maxhp += Mathf.RoundToInt((currenthp * 0.05f) * ((100 - level) * 0.1f));
        currenthp = Maxhp;
    }
  
    
}

   
    


