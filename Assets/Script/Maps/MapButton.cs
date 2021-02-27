using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapButton : MonoBehaviour
{
    public SelectMap SelectMap;
    public MapManager MapManager;
    public GameObject Background;

    // Start is called before the first frame update

    private void Awake()
    {
        SelectMap = GameObject.Find("SecondMap").GetComponent<SelectMap>();
        MapManager = GameObject.Find("MapManager").GetComponent<MapManager>();

    }

    public void ChangeGameScene()
    {
        if (MapManager.Instance.CurrentMap == MapID.FirstMap)
        {
            if (DataManager.playergold >= MapManager.MapGold[0])
            {
                SceneManager.LoadScene("FirstMapSCN");
                DataManager.playergold -= MapManager.MapGold[0];
                DataManager.currentMapid = 0;
            }

        }
        else if (MapManager.Instance.CurrentMap == MapID.SecondMap)
        {
            if (DataManager.playergold >= MapManager.MapGold[1])
            {
                SceneManager.LoadScene("SecondMapSCN");
                DataManager.playergold -= MapManager.MapGold[1];
                DataManager.currentMapid = 1;
            }
            else
            {
                Background.SetActive(false);
            }
        }
        else
        {
            return;
        }
        

    }    
/*    public void buy()
    {
        if (GameManager.playergold >= MapManger.)
        {
            GameManager.playergold -= GameManager.firstmapgold;
        }
        else
        {
            return;
        }
    }*/
}
