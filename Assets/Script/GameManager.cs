using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using System.IO;

public enum ItemIndex : int
{
    Fish = 0, Milk = 1, K2C1 = 2, Guitar = 3
}

[System.Serializable]
public class ItemClass
{
    public string ItemName;
    public int ItemPoint;
    public int ItmeVolume;

    public ItemClass(string input_ItemName, int input_ItemPoint, int input_ItmeVolume)
    {
        this.ItemPoint = input_ItemPoint;
        this.ItemName = input_ItemName;
        this.ItmeVolume = input_ItmeVolume;
    }
} //(string input_ItemName, int input_ItemPoint, int input_ItmeVolume)

public class GameManager : MonoBehaviour
{
    public static List<ItemClass> ItemList = new List<ItemClass>();
    public static int tmpPoint;
    public static int TotalPoint;

    public float CurrentTime;
    public Text GameTimeText;
    public GameObject Background;

    private void Start()
    {
        LoadItemData(DataManager.filePath);

        tmpPoint = 0;
        TotalPoint = 0;
        Time.timeScale = 1;
    }
    void Update()
    {
        if (CurrentTime > 0.0f)
        {
            CurrentTime -= Time.deltaTime;
            GameTimeText.text = "" + (int)CurrentTime;
        }

        else/* if (CurrentTime =< 0.0f)*/
        {
            Background.SetActive(true);
            GameTimeText.text = "게임종료";
            Time.timeScale = 0.0f;
        }
    }

    private void LoadItemData(string FilePath)
    {
        if (!File.Exists(FilePath + "/ItemList.json"))
        {
            ResetItemList();
        }

        string itemData = File.ReadAllText(FilePath + "/ItemList.json");
        ItemList = JsonConvert.DeserializeObject<List<ItemClass>>(itemData);
    }

    [ContextMenu("Reset ItemData")]
    void ResetItemList()
    {
        ItemList.Add(new ItemClass("Fish", 1, 1));
        ItemList.Add(new ItemClass("Milk", 2, 1));
        ItemList.Add(new ItemClass("K2C1", 3, 4));
        ItemList.Add(new ItemClass("Guitar", 4, 3));
        string itemData = JsonConvert.SerializeObject(ItemList, Formatting.Indented);

        File.WriteAllText(DataManager.filePath + "/ItemList.json", itemData);
    }

}

[System.Serializable]
public class SlotData
{
    public bool IsEmpty;
    public GameObject SlotObj;

    public SlotData(bool input_isEmpty, GameObject input_slotObj)
    {
        this.IsEmpty = input_isEmpty;
        this.SlotObj = input_slotObj;
    }
}
