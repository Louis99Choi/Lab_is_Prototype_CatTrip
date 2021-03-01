using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectMap : MonoBehaviour
{
    [SerializeField]
    public MapIndex MapName;
    public GameObject Background;
    public Text MenuText;
    public Text ButtonText;


    public const string V = "이동에는 ";
    public const string S = "G가 필요합니다.";
    public string[] ButtonString;
    public MapManager MapManager;

 

    void Start()
    {
        ButtonString[0] = "이동하기!";
        ButtonString[1] = "잔액부족!";
    }

    void CheckMapGold(MapIndex WhatisSelectedMap)
    {
        Background.SetActive(true);
        MenuText.text = V + DataManager.MapList[(int)WhatisSelectedMap].MapCost + S;

        if (DataManager.playergold >= DataManager.MapList[(int)WhatisSelectedMap].MapCost)
        {
            ButtonText.text = ButtonString[0];
        }
        else
        {
            ButtonText.text = ButtonString[1];
        }
    }

    public void OnMouseDown()
    {
        MapManager.Instance.SelectedMap = MapName;

        CheckMapGold(MapManager.Instance.SelectedMap);

    }
}
