using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Maps
{
    FirstMap, SecondMap
}

public class MapManager : MonoBehaviour
{
    public static MapManager Instance;
    public Maps CurrentMap;

    public GameObject Background;

    public int[] MapGold;





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
