using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class CharacterAbsordModifier : CharacterStatModifierSO
{
    public TypeAbsord typeAbsord;
    public override void AffectCharacter(GameObject character, float val)
    {
        if(typeAbsord== TypeAbsord.MP)
        {
            AttackFunction.Instance.ManaAbsorb +=(int) val;
            PlayerData.Intance.characterData.ManaAbsorb = AttackFunction.Instance.ManaAbsorb;
        }
        else
        {
            AttackFunction.Instance.BloodAbsorb += (int)val;
            PlayerData.Intance.characterData.BloodAbsorb = AttackFunction.Instance.BloodAbsorb;
        }
    }
    
}
public enum TypeAbsord { HP,MP}
