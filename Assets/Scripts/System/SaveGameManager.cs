using Inventory.Model;
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
    public List<InventorySO> listInventory;
    public InventorySO Inventory;
    public List<InventorySO> listInventoryUsingItem;
    public InventorySO InventoryUsingItem;
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
                Inventory = listInventory[i];
                InventoryUsingItem = listInventoryUsingItem[i];
            }

        }
        LoadData();
        
    }
    public void SaveData()
    {
        if (gameData == GameData[0])
        {
            SaveDataPlayer("gameData.json", "gameDataInventory.json", "gameDataInventoryUsingItem.json");
        }
        else
        {
            SaveDataPlayer("gameData2.json", "gameDataInventory2.json", "gameDataInventoryUsingItem2.json");

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
            LoadDataPlayer("gameData.json", "gameDataInventory.json", "gameDataInventoryUsingItem.json");
        }
        else
        {
            LoadDataPlayer("gameData2.json", "gameDataInventory2.json", "gameDataInventoryUsingItem2.json");
        }

    }
    private void OnApplicationQuit()
    {
        SaveData();

    }
    public void SaveDataPlayer(string jsonDataName, string jsonDatainventoryName, string jsonDatainventoryUsingItemName)
    {
        string filePath = Path.Combine(Application.persistentDataPath, jsonDataName);
        string jsonData = JsonUtility.ToJson(gameData);
        File.WriteAllText(filePath, jsonData);
        //Data Inventory
        string filePathInentory = Path.Combine(Application.persistentDataPath, jsonDatainventoryName);
        string jsonDatainventory = JsonUtility.ToJson(Inventory);
        File.WriteAllText(filePathInentory, jsonDatainventory);
        //Data Inventory Using Item
        string filePathInentoryUsingItem = Path.Combine(Application.persistentDataPath, jsonDatainventoryUsingItemName);
        string jsonDatainventoryUsingItem = JsonUtility.ToJson(InventoryUsingItem);
        File.WriteAllText(filePathInentoryUsingItem, jsonDatainventoryUsingItem);
        Debug.Log("Game data saved.");
        PlayerPrefs.SetInt("HasSaveData", 1);
        PlayerPrefs.Save();
        hasSaveData = true;
    }
    public void LoadDataPlayer(string jsonDataName, string jsonDatainventoryName, string jsonDatainventoryUsingItemName)
    {
        string filePath = Path.Combine(Application.persistentDataPath, jsonDataName);
        string filePathInentory = Path.Combine(Application.persistentDataPath, jsonDatainventoryName);
        string filePathInentoryUsingItem = Path.Combine(Application.persistentDataPath, jsonDatainventoryUsingItemName);
        if (File.Exists(filePath) && hasSaveData)
        {
            string jsonData = File.ReadAllText(filePath);
            JsonUtility.FromJsonOverwrite(jsonData, gameData);
            string jsonDatainventory = File.ReadAllText(filePathInentory);
            JsonUtility.FromJsonOverwrite(jsonDatainventory, Inventory);
            string jsonDatainventoryUsingItem = File.ReadAllText(filePathInentoryUsingItem);
            JsonUtility.FromJsonOverwrite(jsonDatainventoryUsingItem, InventoryUsingItem);
            Debug.Log(filePath);
            Debug.Log(filePathInentory);
            Debug.Log(filePathInentoryUsingItem);
            Debug.Log("Game data loaded.");
        }
        else
        {
            Debug.Log("No saved game data found.");
        }
    }
}
