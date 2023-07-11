using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class ChacracterDamageModifie : CharacterStatModifierSO
{
    public override void AffectCharacter(GameObject character, float val)
    {
        AttackFunction.Instance.damageAdd +=(int) val;
        if (AttackFunction.Instance.IsTonic == true)
        {
            AttackFunction.Instance.dmg = (AttackFunction.Instance.OriginalDmg + AttackFunction.Instance.damageAdd) * 2;
        }
        else
        {
            AttackFunction.Instance.UpdateDamage();
        }
    }
}
