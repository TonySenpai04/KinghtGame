using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Rendering;
using UnityEngine.TextCore.Text;

public class SaveGameManager : MonoBehaviour
{
    public static SaveGameManager instance;
    public List<ChacracterData> GameData;
    public ChacracterData gameData;
    public bool hasSaveData = false;
    public GameObject Player;
   

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        string selectedCharacter = PlayerPrefs.GetString("SelectedCharacter");
        for (int i = 0; i < GameData.Count; i++)
        {
            if (GameData[i].name == selectedCharacter)
            {
                gameData = GameData[i];
            }

        }
        LoadData();
        
    }
    public void SaveData()
    {
        if (gameData == GameData[0])
        {
            string filePath = Path.Combine(Application.persistentDataPath, "gameData.json");
            string jsonData = JsonUtility.ToJson(gameData);
            File.WriteAllText(filePath, jsonData);
            Debug.Log("Game data saved.");
            PlayerPrefs.SetInt("HasSaveData", 1);
            PlayerPrefs.Save();
            hasSaveData = true;
        }
        else
        {
            string filePath = Path.Combine(Application.persistentDataPath, "gameData2.json");
            string jsonData = JsonUtility.ToJson(gameData);
            File.WriteAllText(filePath, jsonData);
            Debug.Log("Game data saved.");
            PlayerPrefs.SetInt("HasSaveData", 1);
            PlayerPrefs.Save();
            hasSaveData = true;
        }
    }
    public void LoadData()
    {
        if (PlayerPrefs.HasKey("HasSaveData"))
        {
            hasSaveData = PlayerPrefs.GetInt("HasSaveData") == 1;
        }
        if (gameData == GameData[0])
        {
            string filePath = Path.Combine(Application.persistentDataPath, "gameData.json");
            SaveDataPlayer(filePath);
        }
        else
        {
            string filePath = Path.Combine(Application.persistentDataPath, "gameData2.json");
            SaveDataPlayer(filePath);
        }

        
    }
    private void OnApplicationQuit()
    {
        SaveData();

    }
    public void SaveDataPlayer(string filePath)
    {
        if (File.Exists(filePath) && hasSaveData)
        {
            string jsonData = File.ReadAllText(filePath);
            JsonUtility.FromJsonOverwrite(jsonData, gameData);
            Debug.Log(filePath);
            Debug.Log("Game data loaded.");
        }
        else
        {
            Debug.Log("No saved game data found.");
        }
    }
}
