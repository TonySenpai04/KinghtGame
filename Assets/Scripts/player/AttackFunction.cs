using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AttackFunction : MonoBehaviour
{
    public static AttackFunction Instance;
    public List<SkillS0> skillS0;
    [SerializeField] protected Transform pointatk;
    [SerializeField] protected float radius=1.5f;
    [SerializeField] protected LayerMask mask;
    public AudioClip AttackSound;
    [SerializeField] public InfoCharacter info;
    [Header("Info")]
    [SerializeField] public int dmg = 10;
    [SerializeField] public int Dmg { get => dmg; set => dmg = value; }
   // [SerializeField] private int ExpDmg { get => expDmg; set => expDmg = value; }
    public int DmgClone;
    [SerializeField] public int Crit;
    public int damageAdd;
    public bool Isuse;
    public bool CanX2;

    void Start()
    {
        Instance = this;
        dmg = info.DmgStart;
        DmgClone = dmg;
        CanX2 = true;
        Isuse = false;
    }
    public int AddDamge()
    {
        return damageAdd;
    }
    public void UpdateDamage()
    {
        dmg += damageAdd;
    }

    public void ItemDmg()
    {
        if (UiDamagePlayer.Instance.time > 0)
        {
            Isuse = true;
            if (CanX2 == true)
            {
                dmg *= 2;
            }
            CanX2 = false;
        }
    }
    public void Skill1()
    {
        int TyLeChimang = Random.Range(1, 101);
        if (Crit >= TyLeChimang)
        {
            HpEnemy.Instance.FloatingText.GetComponent<TextMesh>().color = Color.yellow;
            Attack((int)(Dmg * skillS0[0].DmgAdd) * 2, skillS0[0].ManaConsumption);
        }
        else
        {
            HpEnemy.Instance.FloatingText.GetComponent<TextMesh>().color = Color.red;
            Attack((int)(Dmg * skillS0[0].DmgAdd), skillS0[0].ManaConsumption);
            
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
            Attack((int)(Dmg * skillS0[1].DmgAdd) * 2, skillS0[1].ManaConsumption);
        }
        else
        {
            HpEnemy.Instance.FloatingText.GetComponent<TextMesh>().color = Color.red;
            Attack((int)(Dmg * skillS0[1].DmgAdd), skillS0[1].ManaConsumption);

        }

    }
    public void Skill3()
    {
        int TyLeChimang = Random.Range(1, 101);
        if (Crit >= TyLeChimang)
        {
            HpEnemy.Instance.FloatingText.GetComponent<TextMesh>().color = Color.yellow;
            Attack((int)(Dmg * skillS0[2].DmgAdd) * 2, skillS0[2].ManaConsumption);
        }
        else
        {
            HpEnemy.Instance.FloatingText.GetComponent<TextMesh>().color = Color.red;
            Attack((int)(Dmg * skillS0[2].DmgAdd), skillS0[2].ManaConsumption);

        }

    }
    public void Attack(int Dmg,int Mp)
    {
            Collider2D[] enemy = Physics2D.OverlapCircleAll(pointatk.transform.position, radius, mask);
            foreach (Collider2D var in enemy)
            {
            if (var != null)
            {
                var.GetComponent<HpEnemy>().TakeDamageEnemy(Dmg);
                MPController.Instance.MpAttack(Mp);
            }
          }
    }
    //protected void UpdateUI()
    //{
    //    if (DmgClone > info.MaxDmg)
    //    {
    //        DmgClone = info.MaxDmg;
    //    }
    //    textdmg.text = "DMG:" + dmg.ToString("#,##").Replace(',', '.');
    //    CritText.text = "Crit:" + Crit + "%";
    //}
    
}
