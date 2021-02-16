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
    public int[] MapGold;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        MapManger.Instance.CurrentMap = Map;
        if(Map == Maps.FirstMap)
        {
            Background.SetActive(true);
            Text.text = V + MapGold[0] + S;
            return;
        }
        else if (Map == Maps.SecondMap)
        {
            Background.SetActive(true);
            Text.text = V + MapGold[1] + S;
            return;
        }    
        else
        {
            return;
        }
    }
}
