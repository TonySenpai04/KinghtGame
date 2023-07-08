using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class CharacterArmorModifier : CharacterStatModifierSO
{
    public override void AffectCharacter(GameObject character, float val)
    {
        DefencePlayer.Instance.Defense += (int)val;
        DefencePlayer.Instance.DefenseClone += (int)val;
        UIDefense.Instance.UpdateUI();
    }
}
