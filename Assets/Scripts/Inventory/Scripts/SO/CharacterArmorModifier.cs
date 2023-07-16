using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class CharacterArmorModifier : CharacterStatModifierSO
{
    public override void AffectCharacter(GameObject character, float val)
    {
        
        if (DefencePlayer.Instance.IsTonic==true)
        {
            DefencePlayer.Instance.Defense += 2*(int)val;
            DefencePlayer.Instance.DefenseClone += 2*(int)val;
            PlayerData.Intance.characterData.Defense +=(int) val;
        }
        else
        {
            DefencePlayer.Instance.Defense += (int)val;
            DefencePlayer.Instance.DefenseClone += (int)val;
            PlayerData.Intance.characterData.Defense = DefencePlayer.Instance.Defense;

        }
        UIDefense.Instance.UpdateUI();
    }
}
