using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using System.IO;

public class MainButton : MonoBehaviour
{
    List<PlayerClass> PlayerList = new List<PlayerClass>();

    public void ChangeGameScene()
    {
        DataManager.playergold += GameManager.TotalPoint * (int)50;

        PlayerList.Add(new PlayerClass(DataManager.playerid, DataManager.currentMapindex, DataManager.playergold));

        string playerData = JsonConvert.SerializeObject(PlayerList, Formatting.Indented);
        File.WriteAllText(DataManager.filePath + "/PlayerList.json", playerData);

        SceneManager.LoadScene("Maps");
    }
}
