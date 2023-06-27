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
    [SerializeField] public int Dmg { get => dmg; set => dmg = value; }
    [SerializeField] private int ExpDmg { get => expDmg; set => expDmg = value; }
    public float DmgAddSkill1 { get => dmgAddSkill1; set => dmgAddSkill1 = value; }
    public float DmgAddSkill2 { get => dmgAddSkill2; set => dmgAddSkill2 = value; }

    [SerializeField] private GameObject FloatingTextExp;
    public int DmgSkill2;
    public int DmgClone;
    [SerializeField] public int Crit;
    public int damageAdd;
    
    void Start()
    {
        instance = this;
        dmg = info.DmgStart;
        DmgClone = dmg;
        //pointatk = GameObject.Find("PointAttack").transform;
        textdmg.text = "DMG:" + dmg; 
        source = GetComponent<AudioSource>();
    }
    public int AddDamge()
    {
        return damageAdd;
    }
    public void UpdateDamage()
    {
        dmg += damageAdd;
    }

    void Update()
    {
        UpdateUI();
        DmgClone = dmg;
    }

    public void Skill1()
    {
        int TyLeChimang = Random.Range(1, 101);
        if (Crit >= TyLeChimang)
        {
            HpEnemy.Instance.FloatingText.GetComponent<TextMesh>().color = Color.yellow;
            Attack((int)(Dmg * DmgAddSkill1) * 2, 1);
        }
        else
        {
            HpEnemy.Instance.FloatingText.GetComponent<TextMesh>().color = Color.red;
            Attack((int)(Dmg * DmgAddSkill1), 1);
            
        }
    }
    protected void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointatk.position, radius);
    }
    public void IncreaseAtk(int level)
    {
        DmgClone += Mathf.RoundToInt((DmgClone * 0.037f) * ((100 - level) * 0.1f));
        if (DmgClone > info.MaxDmg)
        {
            DmgClone = info.MaxDmg;
        }
        dmg = DmgClone + damageAdd;


    }
    public void Skill2()
    {
        int TyLeChimang = Random.Range(1, 101);
        if (Crit >= TyLeChimang)
        {
            HpEnemy.Instance.FloatingText.GetComponent<TextMesh>().color = Color.yellow;
            Attack((int)(Dmg * DmgAddSkill2) * 2, 3);
        }
        else
        {
            HpEnemy.Instance.FloatingText.GetComponent<TextMesh>().color = Color.red;
            Attack((int)(Dmg * DmgAddSkill2), 3);

        }

    }
   public void Attack(int Dmg,int Mp)
    {
            Collider2D[] enemy = Physics2D.OverlapCircleAll(pointatk.transform.position, radius, mask);
            foreach (Collider2D var in enemy)
            {
                var.GetComponent<HpEnemy>().TakeDamageEnemy(Dmg);
                MPController.instance.MpAttack(Mp);
            }
    }
    protected void UpdateUI()
    {
        if (DmgClone > info.MaxDmg)
        {
            DmgClone = info.MaxDmg;
        }
        textdmg.text = "DMG:" + dmg.ToString("#,##").Replace(',', '.');
        CritText.text = "Crit:" + Crit + "%";
    }
    
}
