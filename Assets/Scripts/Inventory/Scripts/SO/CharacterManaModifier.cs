using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class CharacterManaModifi : CharacterStatModifierSO
{
    public override void AffectCharacter(GameObject character, float val)
    {
        MPController.Instance.addMp = (int)val;
        MPController.Instance.UpdateMp();
    }
}
