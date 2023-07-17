using Inventory.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Player", menuName = "player/Player")]
[System.Serializable]
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
    public int currentXp;
    public int nextLevelXp;
    public int MaxLevel;
    [Header("Gold_Diamond")]
    public float Gold;
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
    [Header("Bottle")]
    public int QuantityHpBotte=10;
    public int QuantityMPBotte=10;
  
    public ChacracterData() { }

}
