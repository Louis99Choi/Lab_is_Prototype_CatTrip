using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapText : MonoBehaviour
{
    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();
    }
    void Update()
    {
        if(MapManager.Instance.SelectPamphlet == PamphletIndex.FirstPamphlet)
        {
            if(MapManager.Instance.SelectedMap == MapIndex.FirstMap)
            {
                text.text = "팜1맵1";
            }
            else if(MapManager.Instance.SelectedMap == MapIndex.SecondMap)
            {
                text.text = "팜1맵2";
            }
        }
        else if(MapManager.Instance.SelectPamphlet == PamphletIndex.SecondPamphlet)
        {
            {
                if (MapManager.Instance.SelectedMap == MapIndex.FirstMap)
                {
                    text.text = "팜2맵1";
                }
                else if (MapManager.Instance.SelectedMap == MapIndex.SecondMap)
                {
                    text.text = "팜2맵2";
                }
            }
        }
    }
}
