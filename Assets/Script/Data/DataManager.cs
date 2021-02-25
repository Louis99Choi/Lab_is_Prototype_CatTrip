using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.IO;

[System.Serializable]
public class MapClass
{
    public string MapName;
    public int MapCost;
    public bool IsOpen;

    public MapClass(string input_MapName, int input_MapCost, bool input_IsOpen)
    {
        this.MapName = input_MapName;
        this.MapCost = input_MapCost;
        this.IsOpen = input_IsOpen;
    }
} //(string input_MapName, int input_MapCost, bool input_IsOpen)

[System.Serializable]
public class ItemClass
{
    public string ItemName;
    public int ItmeVolume;

    public ItemClass(string input_ItemName, int input_ItmeVolume)
    {
        this.ItemName = input_ItemName;
        this.ItmeVolume = input_ItmeVolume;
    }
} //(string input_ItemName, int input_ItmeVolume)

public class DataManager : MonoBehaviour
{

    List<MapClass> MapList = new List<MapClass>();
    List<ItemClass> ItemList = new List<ItemClass>();

    private void Start()
    {
        MapClass FirstMapInfo = new MapClass("FirstMap", 0, true);
        MapClass SecondMapInfo = new MapClass("SecondMap", 100, false);

        MapList.Add(FirstMapInfo);
        MapList.Add(SecondMapInfo);

        ItemList.Add(new ItemClass("Fish", 2));
        ItemList.Add(new ItemClass("Milk", 1));
        ItemList.Add(new ItemClass("K2C1", 4));
        ItemList.Add(new ItemClass("Guitar", 4));

    }
    
    [ContextMenu("MapInfo To Json Data")]
    void SaveMapInfoToJson()
    {
        string mapData = JsonConvert.SerializeObject(MapList, Formatting.Indented);
        //File.WriteAllText(Application.persistentDataPath + "/MapList.json", mapData);
        File.WriteAllText(Application.dataPath + "/MapList.json", mapData);
    }
    [ContextMenu("ItemInfo To Json Data")]
    void SaveItemInfoToJson()
    {
        string itemData = JsonConvert.SerializeObject(ItemList, Formatting.Indented);
        //File.WriteAllText(Application.persistentDataPath + "/ItemList.json", itemData);
        File.WriteAllText(Application.dataPath + "/ItemList.json", itemData);
    }
    
    [ContextMenu("MapInfo From Json Data")]
    void LoadMapInfoToJson()
    {
        string mapData = File.ReadAllText(Application.dataPath + "/MapList.json");
        MapList = JsonConvert.DeserializeObject<List<MapClass>>(mapData);
        Debug.Log(MapList[1].MapCost);
        
    }
    [ContextMenu("ItemInfo From Json Data")]
    void LoadItemInfoToJson()
    {
        string itemData = File.ReadAllText(Application.dataPath + "/ItemList.json");
        ItemList = JsonConvert.DeserializeObject<List<ItemClass>>(itemData);
        Debug.Log(ItemList[0].ItemName);
    }

}
