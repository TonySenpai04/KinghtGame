using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu]
public class CharacterBloodTonic : CharacterStatModifierSO
{
    public TypeBuff TypeBuff;
    public override void AffectCharacter(GameObject character, float val)
    {
        if (TypeBuff == TypeBuff.HP)
        {
            PlayerUI.instance.time += val;
            HPController.instance.ItemHP();
        }
        else if(TypeBuff == TypeBuff.MP)
        {
            PlayerUIMp.Instance.time += val;
            MPController.instance.ItemMP();
        }
        
    }
    
  
    
}
public enum TypeBuff { HP,MP,Dmg}
