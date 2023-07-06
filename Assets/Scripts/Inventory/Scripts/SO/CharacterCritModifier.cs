using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class CharacterCritModifier : CharacterStatModifierSO
{
    public override void AffectCharacter(GameObject character, float val)
    {
        AttackFunction.instance.Crit += (int)val;
    }
}
