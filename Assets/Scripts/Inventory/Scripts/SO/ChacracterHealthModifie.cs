using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu]
public class ChacracterHealthModifie : CharacterStatModifierSO
{
  
    public override void AffectCharacter(GameObject character, float val)
    {
        HPController.Instance.AddHp +=(int) val;
        PlayerData.Intance.characterData.HpAdd = HPController.Instance.AddHp;
        PlayerData.Intance.characterData.HpStart = HPController.Instance.OriginalHP + HPController.Instance.AddHp;
        if (HPController.Instance.IsTonic == true)
        {
            HPController.Instance.maxHp = (HPController.Instance.OriginalHP + HPController.Instance.AddHp) * 2;
        }
        else
        {
            HPController.Instance.maxHp = HPController.Instance.OriginalHP + HPController.Instance.AddHp;
        }
    }
}
