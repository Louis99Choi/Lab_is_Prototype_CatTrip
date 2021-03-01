using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.IO;

public class MapButton : MonoBehaviour
{
    public GameObject Background;

    private void CompareGoldAndMoveMap(MapIndex WhatisSelectedMap)
    {
        if (DataManager.playergold >= DataManager.MapList[(int)WhatisSelectedMap].MapCost)
        {
            DataManager.playergold -= DataManager.MapList[(int)WhatisSelectedMap].MapCost;
            DataManager.currentMapindex = WhatisSelectedMap;

            SceneManager.LoadScene(DataManager.MapList[(int)WhatisSelectedMap].MapName);

            DataManager.MapList[(int)WhatisSelectedMap].IsOpen = true; //IsOpen의 상태를 변경
        }
        else
        {
            Background.SetActive(false);
        }
    }
    private void SaveMapData()
    {
        string mapData = JsonConvert.SerializeObject(DataManager.MapList, Formatting.Indented);
        File.WriteAllText(DataManager.filePath + "/MapList.json", mapData);
    }

    public void ChangeGameScene()
    {
        CompareGoldAndMoveMap(MapManager.Instance.SelectedMap);
        SaveMapData();
        
    }    

}
