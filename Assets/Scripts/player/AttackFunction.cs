using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AttackFunction : MonoBehaviour
{
    public static AttackFunction instance;
    [Header("UI")]
    [SerializeField]  protected Transform pointatk;
    [SerializeField] protected float radius=1.5f;
    [SerializeField] protected LayerMask mask;
    public AudioClip AttackSound;
    public TextMeshProUGUI textdmg;
    [SerializeField] protected InfoCharacter info;
    [SerializeField] private TextMeshProUGUI CritText;
    [Header("Info")]
    [SerializeField] private int expDmg;
    [SerializeField] private int dmg = 10;
    private AudioSource source;
    [SerializeField] private float dmgAddSkill2;
    [SerializeField] private float dmgAddSkill1;
    [SerializeField] private int Dmg { get => dmg; set => dmg = value; }
    [SerializeField] private int ExpDmg { get => expDmg; set => expDmg = value; }
    public float DmgAddSkill1 { get => dmgAddSkill1; set => dmgAddSkill1 = value; }
    public float DmgAddSkill2 { get => dmgAddSkill2; set => dmgAddSkill2 = value; }

    [SerializeField] private GameObject FloatingTextExp;
    public int DmgSkill2;
    public int DmgClone;
    [SerializeField] private int Crit;
    
    void Start()
    {
        instance = this;
        dmg = info.DmgStart;
        DmgClone = dmg;
        //pointatk = GameObject.Find("PointAttack").transform;
        textdmg.text = "DMG:" + dmg; 
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        UpdateUI();
        DmgClone = dmg;
    }

    public void Attack()
    {
        
       int TyLeChimang = Random.Range(1, 101);
        if (Crit >=TyLeChimang)
        {
            DmgClone *= 2;
            //StartCoroutine(Coutdown());
            HpEnemy.hp.FloatingText.GetComponent<TextMesh>().color=Color.yellow;
            StartCoroutine(Coutdown());
        }
        else
        {
            HpEnemy.hp.FloatingText.GetComponent<TextMesh>().color = Color.red;
        }
        
        Collider2D[] enemy = Physics2D.OverlapCircleAll(pointatk.transform.position, radius, mask);
        foreach (Collider2D var in enemy)
        {
            var.GetComponent<HpEnemy>().TakeDamageEnemy((int)(Dmg * DmgAddSkill1));
            MPController.instance.MpAttack(1);
            HpEnemy.hp.Showfloatingtext(HpEnemy.hp.expDmg);
        }
    }
    protected void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointatk.position, radius);
    }
    public void IncreaseAtk(int level)
    {
        dmg += Mathf.RoundToInt((dmg * 0.037f) * ((100 - level) * 0.1f));
        if (dmg > info.MaxDmg)
        {
            dmg = info.MaxDmg;
        }
       
    }
    IEnumerator ResetDmg()
    {
        yield  return new WaitForSeconds(2f);
        DmgSkill2 = DmgClone;
    }
    public void AttackSkill1()
    {
        DmgSkill2 = (int)(DmgClone * DmgAddSkill2);
        StartCoroutine(ResetDmg());
        int TyLeChimang = Random.Range(1, 101);
        if (Crit >= TyLeChimang)
        {
            DmgClone *= 2;
            DmgSkill2 *= 2;
            expDmg*=2;
            HpEnemy.hp.FloatingText.GetComponent<TextMesh>().color = Color.yellow;
            StartCoroutine(Coutdown());
        }
        else
        {
            HpEnemy.hp.FloatingText.GetComponent<TextMesh>().color = Color.red;
        }
        Collider2D[] enemy = Physics2D.OverlapCircleAll(pointatk.transform.position, radius, mask);
        foreach (Collider2D var in enemy)
        {
            var.GetComponent<HpEnemy>().TakeDamageEnemy((int)((int)DmgSkill2));
            MPController.instance.MpAttack(2);
            StartCoroutine(Coutdown()); 
        }

      
    }
    protected void UpdateUI()
    {
        if (Dmg > info.MaxDmg)
        {
            Dmg = info.MaxDmg;
        }
        textdmg.text = "DMG:" + dmg.ToString("N1");
        CritText.text = "Crit:" + Crit + "%";
    }
    IEnumerator Coutdown()
    {
        yield return new WaitForSeconds(1.2f);
        DmgClone /= 2;
        DmgSkill2 /= 2;
        HpEnemy.hp.FloatingText.GetComponent<TextMesh>().color = Color.red;
    }
    
}
