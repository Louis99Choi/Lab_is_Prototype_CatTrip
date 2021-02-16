using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Maps
{
    FirstMap, SecondMap
}

public class MapManger : MonoBehaviour
{
    public static MapManger Instance;
    public Maps CurrentMap;

    public GameObject Background;
    public GameObject FirstMap;

    public Text TextBt;

    public int[] MapGold;

    public string[] talk;



    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != null)
        {
            return;
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Background.SetActive(false);
        }

        if (GameManager.playergold >= MapGold[0])
        {
            TextBt.text = talk[0];
        }
        else
        {
            TextBt.text = talk[1];
        }

    }
/*    public void OnMouseDown(GameObject Maps)
    {
        if(Maps = FirstMap)
        {
            Background.SetActive(true);
            Text[0].text = V + MapGold[0] + S;
            return;
        }
        else
        {
            return;
        }
    }*/
}
