using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class ChacracterDamageModifie : CharacterStatModifierSO
{
    public override void AffectCharacter(GameObject character, float val)
    {
        AttackFunction.Instance.damageAdd =(int) val;
        AttackFunction.Instance.UpdateDamage();
    }
}
