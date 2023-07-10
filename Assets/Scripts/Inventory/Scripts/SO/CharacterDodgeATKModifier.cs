using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class CharacterDodgeATKModifier : CharacterStatModifierSO
{
    public override void AffectCharacter(GameObject character, float val)
    {
        HPController.Instance.dodgeAttack += (int)val;
    }
}
