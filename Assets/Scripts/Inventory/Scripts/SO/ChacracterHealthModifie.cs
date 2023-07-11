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
        if (HPController.Instance.IsTonic == true)
        {
            HPController.Instance.maxhp = (HPController.Instance.OriginalHP + HPController.Instance.AddHp) * 2;
        }
        else
        {
            HPController.Instance.UpdateHP();
        }
    }
}
