using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Player", menuName = "player/Player")]
public class ChacracterData : ScriptableObject
{
    public int HpStart;
    public int CurrentHP;
    public int MaxDmg;
    public int DmgStart;
    public int HpMax;
    public int MpStart;
    public int CurrentMP;
    public int MaxMp;
    public int Level;
    public float currentXp;
    public int nextLevelXp;
    public int MaxLevel;
    public int Gold;
    public float Diamond;
    public int HpReset;
    public int MpReset;
    public int DmgReset;
    public void ResetData()
    {
        Level = 1;
        currentXp = 0;
        nextLevelXp = 100;
        HpStart = HpReset;
        MpStart = MpReset;
        DmgStart = DmgReset;
    }
}
