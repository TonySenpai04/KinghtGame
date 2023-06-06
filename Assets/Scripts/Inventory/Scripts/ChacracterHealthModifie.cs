using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu]
public class ChacracterHealthModifie : CharacterStatModifierSO
{
   
    
    public override void AffectCharacter(GameObject character, float val)
    {
        character = GameObject.Find("Player");
        //Hpplayer hpplayer = character.GetComponent<Hpplayer>();
        //if (hpplayer != null)
        //{
        //    hpplayer.RecuperateHp();
        //}
        Debug.Log("1");
    }
}
