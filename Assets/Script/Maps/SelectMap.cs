using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectMap : MonoBehaviour
{
    [SerializeField]
    public Maps Map;
    public GameObject Background;
    public Text Text;
    public const string V = "이동에는 ";
    public const string S = "G가 필요합니다.";
    public MapManager MapManager;

    // Start is called before the first frame update

    private void Awake()
    {
        MapManager = GameObject.Find("MapManager").GetComponent<MapManager>();
    }

    void Start()
    {
        MapManager.MapGold[0] = 0;
        MapManager.MapGold[1] = 100;
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
            Text.text = V + MapManager.MapGold[0] + S;
            MapManager.MapGold[1] += 50; 
            return;
        }
        else if (Map == Maps.SecondMap)
        {
            Background.SetActive(true);
            Text.text = V + MapManager.MapGold[1] + S;
            return;
        }    
        else
        {
            return;
        }
    }
}
