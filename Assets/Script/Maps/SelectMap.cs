using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectMap : MonoBehaviour
{
    [SerializeField]
    public Maps Map;
    public GameObject Background;
    public Text MenuText;
    public Text ButtonText;


    public const string V = "이동에는 ";
    public const string S = "G가 필요합니다.";
    public string[] ButtonString;
    public MapManager MapManager;

 

    // Start is called before the first frame update

    private void Awake()
    {
        MapManager = GameObject.Find("MapManager").GetComponent<MapManager>();
    }

    void Start()
    {

        ButtonString[0] = "이동하기!";
        ButtonString[1] = "잔액부족!";

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        MapManager.Instance.CurrentMap = Map;
        if(Map == Maps.FirstMap)
        {
            Background.SetActive(true);
            MenuText.text = V + MapManager.MapGold[0] + S;
            MapManager.MapGold[1] += 50; 

            if(GameManager.playergold >= MapManager.MapGold[0])
            {
                ButtonText.text = ButtonString[0];
            }
            else
            {
                ButtonText.text = ButtonString[1];
            }
            return;
        }
        else if (Map == Maps.SecondMap)
        {
            Background.SetActive(true);
            MenuText.text = V + MapManager.MapGold[1] + S;

            if (GameManager.playergold >= MapManager.MapGold[1])
            {
                ButtonText.text = ButtonString[0];
            }
            else
            {
                ButtonText.text = ButtonString[1];
            }
            return;
        }    
        else
        {
            return;
        }
    }
}
