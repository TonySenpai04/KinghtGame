using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Player", menuName = "player/Player")]
public class ChacracterData : ScriptableObject
{
    [Header("HP")]
    public int HpStart;
    public int CurrentHP;
    public int HpMax;
    [Header("Dmg")]
    public int MaxDmg;
    public int DmgStart;
    [Header("MP")]
    public int MpStart;
    public int CurrentMP;
    public int MaxMp;
    [Header("Level")]
    public int Level;
    public float currentXp;
    public int nextLevelXp;
    public int MaxLevel;
    [Header("Gold_Diamond")]
    public int Gold;
    public float Diamond;
    [Header("Reset")]
    public int HpReset;
    public int MpReset;
    public int DmgReset;
    [Header("Defense")]
    public int Defense;
    [Header("Crit")]
    public int Crit;
    [Header("DogdeAtk")]
    public int DogdeAtk;
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
