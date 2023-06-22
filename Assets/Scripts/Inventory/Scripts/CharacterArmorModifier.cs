using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class CharacterArmorModifier : CharacterStatModifierSO
{
    public override void AffectCharacter(GameObject character, float val)
    {
        HPController.instance.Armor += (int)val;
    }
}
