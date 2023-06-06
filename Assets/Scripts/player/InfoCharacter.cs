using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Player", menuName = "player/Player")]
public class InfoCharacter : ScriptableObject
{
    // Start is called before the first frame update
    public int HpStart;
    public int MaxDmg;
    public int DmgStart;
    public int HpMax;
    public int MpStart;
    public int MaxMp;
}
