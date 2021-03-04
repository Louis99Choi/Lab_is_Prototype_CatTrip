﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.IO;

[System.Serializable]
public class PlayerClass
{
    public int playerID;
    public MapIndex currentMapIndex;
    public int playerGold; //DataManager 클래스의 static 변수 playergold 와 다른 클래스 변수임

    public PlayerClass(int input_playerID, MapIndex input_currentMapIndex, int input_playerGold)
    {
        this.playerID = input_playerID;
        this.currentMapIndex = input_currentMapIndex;
        this.playerGold = input_playerGold;
    }


} //(int input_playerID, MapIndex input_currentMapIndex, int input_playerGold)

[System.Serializable]
public class MapClass
{
    public string MapTown;
    public string MapName;
    public int MapCost;
    public bool IsOpen;

    public MapClass(string input_MapTown, string input_MapName, int input_MapCost, bool input_IsOpen)
    {
        this.MapTown = input_MapTown;
        this.MapName = input_MapName;
        this.MapCost = input_MapCost;
        this.IsOpen = input_IsOpen;
    }
} //(string input_MapTown, string input_MapName, int input_MapCost, bool input_IsOpen)

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
    public static MapIndex currentMapindex;
    public static int playergold;

    public static string filePath; //Json 파일 저장 경로

    private List<PlayerClass> PlayerList = new List<PlayerClass>();
    public static List<MapClass> MapList = new List<MapClass>();
    //public List<ItemClass> ItemList = new List<ItemClass>();

    [ContextMenu("Reset PlayerData")]
    private void ResetPlayerData()
    {
        PlayerList.Add(new PlayerClass(0, (MapIndex)0, 0));

        string playerData = JsonConvert.SerializeObject(PlayerList, Formatting.Indented);
        File.WriteAllText(DataManager.filePath + "/PlayerList.json", playerData);
    }

    [ContextMenu("Reset MapData")]
    private void ResetMapList()
    {
        MapList.Add(new MapClass("FirstTown", "FirstMap", 0, true));
        MapList.Add(new MapClass("FirstTown", "SecondMap", 100, false));

        string mapData = JsonConvert.SerializeObject(MapList, Formatting.Indented);
        File.WriteAllText(filePath + "/MapList.json", mapData);
    }

    private void LoadPlayerData(string FilePath)
    {
        if(!File.Exists(FilePath + "/PlayerList.json"))
        {
            ResetPlayerData();
        }
        
        string playerData = File.ReadAllText(FilePath + "/PlayerList.json");
        PlayerList = JsonConvert.DeserializeObject<List<PlayerClass>>(playerData);
        //Json파일을 역직렬화한 PlayerList[0] 은 PlayerClass의 객체이며 playerID, currentMapIndex, playerGold 의 정보가 담겨있다.

        playerid = PlayerList[0].playerID;
        currentMapindex = PlayerList[0].currentMapIndex;
        playergold = PlayerList[0].playerGold;
        //Json파일로부터 저장된 player의 데이터를 static 변수 playerid, currentMapindex, playergold에 넣어 게임에 사용
    } //PlayerData를 Json파일로부터 로드하고 파일이 없다면 파일을 초기화 후 생성

    private void LoadMapData(string FilePath)
    {
        if (!File.Exists(FilePath + "/MapList.json"))
        {
            ResetMapList();
        }

        string mapData = File.ReadAllText(FilePath + "/MapList.json");
        MapList = JsonConvert.DeserializeObject<List<MapClass>>(mapData); //MapList 는 PlayerList와 다르게 static 리스트임
        
    }

    private void Start()
    {
        filePath = (string)Application.dataPath + "/Data_JsonFile"; //빌드 시 구현 안되지만 Asset폴더 경로라 개발 중 보기 편함
        //filePath = Application.persistentDataPath + "/Data_JsonFile"; //빌드 시 구현되게 하려면

        /*
        ItemList.Add(new ItemClass(0, "Fish", 2));
        ItemList.Add(new ItemClass(1, "Milk", 1));
        ItemList.Add(new ItemClass(3, "K2C1", 4));
        ItemList.Add(new ItemClass(4, "Guitar", 4));*/

        LoadPlayerData(filePath);
        LoadMapData(filePath);
    }
    
    
    /*[ContextMenu("ItemInfo To Json Data")]
    void SaveItemInfoToJson()
    {
        string itemData = JsonConvert.SerializeObject(ItemList, Formatting.Indented);
        //File.WriteAllText(Application.persistentDataPath + "/ItemList.json", itemData);
        File.WriteAllText(filePath + "/ItemList.json", itemData);
    }*/

    /*[ContextMenu("ItemInfo From Json Data")]
    void LoadItemInfoToJson()
    {
        string itemData = File.ReadAllText(filePath + "/ItemList.json");
        ItemList = JsonConvert.DeserializeObject<List<ItemClass>>(itemData);
        Debug.Log(ItemList[0].ItemName);
    }*/

}
