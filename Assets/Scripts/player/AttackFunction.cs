using Inventory.UI;
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
    [SerializeField] public int dmg = 10;
    [SerializeField] public int Dmg { get => dmg; set => dmg = value; }
    public int OriginalDmg;
    [SerializeField] public int Crit;
    public int damageAdd;
    public bool IsTonic;
    public bool CanX2;
    public int BloodAbsorb = 0;
    public int ManaAbsorb = 0;

    void Start()
    {
        Instance = this;
        dmg = PlayerData.Intance.characterData.DmgStart;
        Crit = PlayerData.Intance.characterData.Crit;
        OriginalDmg = PlayerData.Intance.characterData.OriginalDmg;
        CanX2 = true;
        IsTonic = false;
        damageAdd = PlayerData.Intance.characterData.DmgAdd;
    }
   
    public void ItemDmg()
    {
        if (UiDamagePlayer.Instance.time > 0)
        {
            IsTonic = true;
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
            HpEnemy.Instance.FloatingText.GetComponent<TextMeshPro>().color = Color.yellow;
            Attack((int)(Dmg * skillS0[0].DmgAdd) * 2, skillS0[0].ManaConsumption);
        }
        else
        {
            HpEnemy.Instance.FloatingText.GetComponent<TextMeshPro>().color = Color.red;
            Attack((int)(Dmg * skillS0[0].DmgAdd), skillS0[0].ManaConsumption);
            HPController.Instance.currenthp += Dmg * skillS0[0].DmgAdd * BloodAbsorb;
         

        }
    }
    protected void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointatk.position, radius);
    }
    public void IncreaseAtk(int level)
    {
        OriginalDmg += Mathf.RoundToInt((OriginalDmg * 0.037f) * ((100 - level) * 0.1f));
        PlayerData.Intance.characterData.OriginalDmg = OriginalDmg;
        if (OriginalDmg > PlayerData.Intance.characterData.MaxDmg)
        {
             PlayerData.Intance.characterData.MaxDmg= OriginalDmg;
        }
        dmg = OriginalDmg + damageAdd;
        PlayerData.Intance.characterData.DmgStart = dmg;

    }
    public void Skill2()
    {
        int TyLeChimang = Random.Range(1, 101);
        if (Crit >= TyLeChimang)
        {
            HpEnemy.Instance.FloatingText.GetComponent<TextMeshPro>().color = Color.yellow;
            Attack((int)(Dmg * skillS0[1].DmgAdd) * 2, skillS0[1].ManaConsumption);
        }
        else
        {
            HpEnemy.Instance.FloatingText.GetComponent<TextMeshPro>().color = Color.red;
            Attack((int)(Dmg * skillS0[1].DmgAdd), skillS0[1].ManaConsumption);

        }

    }
    public void Skill3()
    {
        int TyLeChimang = Random.Range(1, 101);
        if (Crit >= TyLeChimang)
        {
            HpEnemy.Instance.FloatingText.GetComponent<TextMeshPro>().color = Color.yellow;
            Attack((int)(Dmg * skillS0[2].DmgAdd) * 2, skillS0[2].ManaConsumption);
        }
        else
        {
            HpEnemy.Instance.FloatingText.GetComponent<TextMeshPro>().color = Color.red;
            Attack((int)(Dmg * skillS0[2].DmgAdd), skillS0[2].ManaConsumption);

        }

    }
    public void Skill4()
    {
        int TyLeChimang = Random.Range(1, 101);
        if (Crit >= TyLeChimang)
        {
            HpEnemy.Instance.FloatingText.GetComponent<TextMeshPro>().color = Color.yellow;
            Attack((int)(Dmg * skillS0[2].DmgAdd) * 2, skillS0[3].ManaConsumption);
        }
        else
        {
            HpEnemy.Instance.FloatingText.GetComponent<TextMeshPro>().color = Color.red;
            Attack((int)(Dmg * skillS0[2].DmgAdd), skillS0[3].ManaConsumption);

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
    
}
