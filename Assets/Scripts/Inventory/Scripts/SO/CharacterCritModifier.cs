using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class CharacterCritModifier : CharacterStatModifierSO
{
    public override void AffectCharacter(GameObject character, float val)
    {
        AttackFunction.Instance.Crit += (int)val;
        PlayerData.Intance.characterData.Crit = AttackFunction.Instance.Crit;

    }
}
