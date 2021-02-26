using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.IO;

[System.Serializable]
public class PlayerClass
{
    //public static PlayerClass instance;
    public int playerID;
    public int currentMapID;
    public int playerGold; //DataManager 클래스의 static 변수 playergold 와 다른 클래스 변수임

    public PlayerClass(int input_playerID, int input_currentMapID, int input_playerGold)
    {
        this.playerID = input_playerID;
        this.currentMapID = input_currentMapID;
        this.playerGold = input_playerGold;
    }

   
} //(int input_playerID, int input_currentMapID, int input_playerGold)

[System.Serializable]
public class MapClass
{
    public int MapID;
    public string MapName;
    public int MapCost;
    public bool IsOpen;

    public MapClass(int input_MapID, string input_MapName, int input_MapCost, bool input_IsOpen)
    {
        this.MapID = input_MapID;
        this.MapName = input_MapName;
        this.MapCost = input_MapCost;
        this.IsOpen = input_IsOpen;
    }
} //(int input_MapID, string input_MapName, int input_MapCost, bool input_IsOpen)

[System.Serializable]
public class ItemClass
{
    public int ItemID;
    public string ItemName;
    public int ItmeVolume;

    public ItemClass(int input_ItemID, string input_ItemName, int input_ItmeVolume)
    {
        this.ItemID = input_ItemID;
        this.ItemName = input_ItemName;
        this.ItmeVolume = input_ItmeVolume;
    }
} //(int input_ItemID, string input_ItemName, int input_ItmeVolume)

public class DataManager : MonoBehaviour
{
    public static int playerid;
    public static int currentMapid;
    public static int playergold;

    public static string filePath; //Json 파일 저장 경로
    public List<PlayerClass> PlayerList = new List<PlayerClass>();

    //List<MapClass> MapList = new List<MapClass>();
    //List<ItemClass> ItemList = new List<ItemClass>();


    private void Start()
    {
        filePath = Application.dataPath + "/Data_JsonFile"; //빌드 시 구현 안되지만 Asset폴더 경로라 개발 중 보기 편함
        //filePath = Application.persistentDataPath + "/Data_JsonFile"; //빌드 시 구현되게 하려면

        /*MapClass FirstMapInfo = new MapClass(0, "FirstMap", 0, true);
        MapClass SecondMapInfo = new MapClass(1, "SecondMap", 100, false);

        PlayerList.Add(playerInfo);
        MapList.Add(FirstMapInfo);
        MapList.Add(SecondMapInfo);

        ItemList.Add(new ItemClass(0, "Fish", 2));
        ItemList.Add(new ItemClass(1, "Milk", 1));
        ItemList.Add(new ItemClass(3, "K2C1", 4));
        ItemList.Add(new ItemClass(4, "Guitar", 4));*/

        string playerData = File.ReadAllText(filePath + "/PlayerList.json");
        PlayerList = JsonConvert.DeserializeObject<List<PlayerClass>>(playerData);
        //Json파일을 역직렬화한 PlayerList[0] 은 PlayerClass의 객체이며 playerID, currentMapID, playerGold 의 정보가 담겨있다.

        playerid = PlayerList[0].playerID;
        currentMapid = PlayerList[0].currentMapID;
        playergold = PlayerList[0].playerGold;
        //Json파일로부터 저장된 player의 데이터를 static 변수 playerid, currentMapid, playergold에 넣어 게임에 사용
    }
    
    [ContextMenu("Reset PlayerData")]
    void resetPlayerData()
    {
        PlayerList[0].playerID = 0;
        PlayerList[0].currentMapID = 0;
        PlayerList[0].playerGold = 0;

        string playerData = JsonConvert.SerializeObject(PlayerList, Formatting.Indented);
        File.WriteAllText(DataManager.filePath + "/PlayerList.json", playerData);
    }
    
    /*[ContextMenu("MapInfo To Json Data")]
    void SaveMapInfoToJson()
    {
        string mapData = JsonConvert.SerializeObject(MapList, Formatting.Indented);
        File.WriteAllText(filePath + "/MapList.json", mapData);
    }
    [ContextMenu("ItemInfo To Json Data")]
    void SaveItemInfoToJson()
    {
        string itemData = JsonConvert.SerializeObject(ItemList, Formatting.Indented);
        //File.WriteAllText(Application.persistentDataPath + "/ItemList.json", itemData);
        File.WriteAllText(filePath + "/ItemList.json", itemData);
    }
    
    [ContextMenu("MapInfo From Json Data")]
    void LoadMapInfoToJson()
    {
        string mapData = File.ReadAllText(filePath + "/MapList.json");
        MapList = JsonConvert.DeserializeObject<List<MapClass>>(mapData);
        Debug.Log(MapList[1].MapCost);
        
    }
    [ContextMenu("ItemInfo From Json Data")]
    void LoadItemInfoToJson()
    {
        string itemData = File.ReadAllText(filePath + "/ItemList.json");
        ItemList = JsonConvert.DeserializeObject<List<ItemClass>>(itemData);
        Debug.Log(ItemList[0].ItemName);
    }*/

}
