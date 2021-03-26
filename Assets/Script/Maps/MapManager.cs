using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;

public enum MapIndex : int
{
    FirstMap = 0, 
    SecondMap = 1,
    ThirdMap = 2,
}

public enum PamphletIndex : int
{
    FirstPamphlet = 0,
    SecondPamphlet = 1,
    ThirdPamphlet = 2,
}

public enum OpenPamphletIndex : int
{
    FirstOpenPamphlet = 0,
    SecondOpenPamphlet = 1,
    ThirdOpenPamphlet = 2,
}

public class MapManager : MonoBehaviour
{
    public static MapManager Instance;
    public MapIndex SelectedMap;
    public PamphletIndex SelectPamphlet;

    public GameObject Background;

    private void Start()
    {
        Time.timeScale = 1.0f;
    }
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
