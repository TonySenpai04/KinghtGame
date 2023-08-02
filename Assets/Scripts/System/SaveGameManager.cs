using Inventory.Model;
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
    public List<DataSkills> SkillsS0;
    public List<AttackFunction> AttackFunctions;
    public DataSkills atk;
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
                atk= SkillsS0[i];
            }

        }
        LoadData();
        
    }
    public void SaveData()
    {
        if (gameData == GameData[0])
        {
            SaveDataPlayer("gameData.json", "gameDataInventory.json", "gameDataInventoryUsingItem.json", "Skill.json");
        }
        else
        {
            SaveDataPlayer("gameData2.json", "gameDataInventory2.json", "gameDataInventoryUsingItem2.json", "Skill2.json");

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
            LoadDataPlayer("gameData.json", "gameDataInventory.json", "gameDataInventoryUsingItem.json","Skill.json");
        }
        else
        {
            LoadDataPlayer("gameData2.json", "gameDataInventory2.json", "gameDataInventoryUsingItem2.json","Skill2.json");
        }

    }
    private void OnApplicationQuit()
    {
        SaveData();

    }
    public void SaveDataPlayer(string jsonDataName, string jsonDatainventoryName, string jsonDatainventoryUsingItemName,string jsonDataSkillName)
    {
        //Data Player
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
        //Skill
        string filePathSkill= Path.Combine(Application.persistentDataPath, jsonDataSkillName);
        string jsonDataSkill = JsonUtility.ToJson(atk);
        File.WriteAllText(filePathSkill, jsonDataSkill);
        Debug.Log("Game data saved.");
        PlayerPrefs.SetInt("HasSaveData", 1);
        PlayerPrefs.Save();
        hasSaveData = true;
    }
    public void LoadDataPlayer(string jsonDataName, string jsonDatainventoryName, string jsonDatainventoryUsingItemName, string jsonDataSkillName)
    {
        string filePath = Path.Combine(Application.persistentDataPath, jsonDataName);
        string filePathInentory = Path.Combine(Application.persistentDataPath, jsonDatainventoryName);
        string filePathInentoryUsingItem = Path.Combine(Application.persistentDataPath, jsonDatainventoryUsingItemName);
        string filePathSkill = Path.Combine(Application.persistentDataPath, jsonDataSkillName);
        if (File.Exists(filePath) && hasSaveData)
        {
            //Data Player
            string jsonData = File.ReadAllText(filePath);
            JsonUtility.FromJsonOverwrite(jsonData, gameData);
            //Data Inventory
            string jsonDatainventory = File.ReadAllText(filePathInentory);
            JsonUtility.FromJsonOverwrite(jsonDatainventory, Inventory);
            //Data Inventory Using Item
            string jsonDatainventoryUsingItem = File.ReadAllText(filePathInentoryUsingItem);
            JsonUtility.FromJsonOverwrite(jsonDatainventoryUsingItem, InventoryUsingItem);
            //Skill
            string jsonDataSkill = File.ReadAllText(filePathSkill);
            JsonUtility.FromJsonOverwrite(jsonDataSkill, atk);
            Debug.Log("Game data loaded.");
        }
        else
        {
            Debug.Log("No saved game data found.");
        }
    }
}
