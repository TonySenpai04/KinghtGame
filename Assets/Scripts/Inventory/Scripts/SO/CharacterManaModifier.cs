using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class CharacterManaModifi : CharacterStatModifierSO
{
    public override void AffectCharacter(GameObject character, float val)
    {
        MPController.Instance.addMp += (int)val;
        PlayerData.Intance.characterData.MpStart = MPController.Instance.OriginalMp + MPController.Instance.addMp;
        if (MPController.Instance.IsTonic == true)
        {
            MPController.Instance.Maxmp = (MPController.Instance.OriginalMp + MPController.Instance.addMp) * 2;
           
        }
        else
        {
            MPController.Instance.UpdateMp();
           
        }
    }
}
