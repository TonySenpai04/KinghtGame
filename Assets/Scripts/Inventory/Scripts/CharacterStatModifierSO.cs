using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public abstract class CharacterStatModifierSO : ScriptableObject
{

    public abstract void AffectCharacter(GameObject character, float val);
}
