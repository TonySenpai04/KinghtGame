using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterData
{
    // Các thuộc tính của dữ liệu nhân vật
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
    [Header("Position")]
    public int XPos;
    public int YPos;
}

public class CharacterManager : MonoBehaviour
{
    public CharacterData characterData;

    // Các phương thức cập nhật và truy cập dữ liệu

    public void UpdateCharacterData(CharacterData newData)
    {
        characterData = newData;
        // Ở đây, bạn có thể thực hiện các xử lý và cập nhật khác nếu cần
    }
}
