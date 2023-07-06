using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu]
public class ChacracterHealthModifie : CharacterStatModifierSO
{
  
    public override void AffectCharacter(GameObject character, float val)
    {
        HPController.instance.AddHp =(int) val;
        HPController.instance.UpdateHP();
    }
}
