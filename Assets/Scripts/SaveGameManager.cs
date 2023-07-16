using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using UnityEngine;

public class SaveGameManager : MonoBehaviour
{
    public static SaveGameManager instance;
    
    private void Start()
    {
        instance = this; 
        
    }
    public void SaveData()
    {
        PlayerPrefs.SetInt("Curenthealth", PlayerData.Intance.characterData.CurrentHP);
        PlayerPrefs.SetInt("CurrenyMana", PlayerData.Intance.characterData.CurrentMP);
        PlayerPrefs.SetInt("CurrentExp", PlayerData.Intance.characterData.currentXp);
        PlayerPrefs.SetInt("Dmg", PlayerData.Intance.characterData.DmgStart);
        PlayerPrefs.SetInt("Hp", PlayerData.Intance.characterData.HpStart);
        PlayerPrefs.SetInt("Mana", PlayerData.Intance.characterData.CurrentMP);
        PlayerPrefs.SetInt("Level", PlayerData.Intance.characterData.Level);
    }
    private void OnApplicationQuit()
    {
        SaveData();
        
    }
}
