using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class HpEnemy : Healthsystem
{
    public EnemyScriptableInfo Enemy;
    public GameObject FloatingText;
    public static HpEnemy hp;
    protected Animator animator;
    [SerializeField]private float ScaleX;
    [SerializeField] public int expDmg;
    public GameObject FloatingTextExp;
    protected Transform player;
    [SerializeField] private float respawnTime;
    
    private void Awake()
    {
        Maxhp = Enemy.MaxHp;
        healthbar.setmaxh(Maxhp);
        currenthp = Maxhp;
        hp = this;
    }
    
    void Start()
    {
        respawnTime = 10;
        animator = GetComponent<Animator>();
        healthbar.setmaxh(Maxhp);
        healthbar.sethp(currenthp);
        player = GameObject.Find("player").transform;
       
    }
    void Update()
    {
       
        UpdateUI();
        Flip();
      

    } 
    public void TakeDamageEnemy(int Dmg)
    {
        currenthp -= Dmg;
        animator.SetTrigger("ishit");
        healthbar.sethp(currenthp);
        if (currenthp < 0)
        {
            currenthp = 0;
        }
        if (currenthp > Maxhp)
        {
            currenthp = Maxhp;
        }
        if (FloatingText != null && currenthp > 0)
        {
            Showfloatingtext(Dmg);
        }
        if (currenthp == 0)
        {
           
            StartCoroutine(Enemydie());
        }
        if (LevelSystem.mylevel.IsUse == false && currenthp>0)
        {
            //expDmg = (int)((int)Random.Range((Enemy.MaxHp * 0.03f), (Enemy.MaxHp * 0.05f)) + 0.01f * Dmg);
            expDmg = (int)((int)Random.Range((Enemy.MaxHp * 3f), (Enemy.MaxHp * 5f)) + 10f * Dmg);

            LevelSystem.mylevel.GainExperienceFlatRate(expDmg);
        }
        else if (LevelSystem.mylevel.IsUse == true && currenthp > 0)
        {
            //expDmg =2* (int)((int)Random.Range((Enemy.MaxHp * 0.03f), (Enemy.MaxHp * 0.05f)) + 0.01f * Dmg);
            expDmg =2* (int)((int)Random.Range((Enemy.MaxHp * 3f), (Enemy.MaxHp * 5f)) + 10f * Dmg);
            LevelSystem.mylevel.GainExperienceFlatRate(expDmg);
        }
        if (LevelSystem.mylevel.level < 30 && currenthp > 0)
        {
            ShowfloatingExp(expDmg);
        }
    }
   public void Showfloatingtext(int expDmg)
    {
            var Text = Instantiate(FloatingText, transform.position, Quaternion.identity, transform);
            Text.GetComponent<TextMesh>().text = "-" + expDmg.ToString();
    }
    IEnumerator Enemydie()
    {
        GetComponent<DropItem>().CreateItem(transform.position);
        //DropItem.Instance.CreateItem(transform.position);
        animator.SetTrigger("isdead");
        healthbar.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnTime);
        gameObject.SetActive(false);
        Currenthp += Maxhp;
        //yield return new WaitForSeconds(3f);
        healthbar.sethp(Maxhp);
        healthbar.gameObject.SetActive(true);
        gameObject.SetActive(true);
       // healthbar.gameObject.SetActive(true);

    }
    protected new void UpdateUI()
    {
       
        healthText.text = currenthp + "/" + Maxhp;
    }
    public void Flip()
    {
        Vector3 localScale = transform.localScale;
        Vector3 hpbarscale = healthbar.transform.localScale;
        if (localScale.x < 0)
        {
            
            hpbarscale.x = -ScaleX;
            healthbar.transform.localScale=hpbarscale;
        }
        else if(localScale.x>0)
        {
            
            hpbarscale.x = ScaleX;
            healthbar.transform.localScale = hpbarscale;
        }
    }
    void ShowfloatingExp(int Exp)
    {
        var Text = Instantiate(FloatingTextExp,player. transform.position, Quaternion.identity,player. transform);
        Text.GetComponent<TextMesh>().text = "+" + Exp.ToString();
    }
}
