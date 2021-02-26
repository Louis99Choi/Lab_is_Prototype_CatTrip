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
 

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Background.SetActive(false);
        }

 
    }

}
