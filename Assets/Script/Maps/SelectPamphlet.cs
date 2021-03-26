using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectPamphlet : MonoBehaviour
{
    [SerializeField]
    PamphletIndex PamphletName;

    
    public static bool IsPamphletOpen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckSelectedPamphlet()
    {
        MapManager.Instance.SelectPamphlet = PamphletName;
        var PamNum = (int)PamphletName;
        GameObject.Find("Canvas").transform.Find("Back").transform.Find("Pamphlet" + PamNum.ToString()).gameObject.SetActive(true);
        IsPamphletOpen = true;
    }

    public void OnMouseDown()
    {
        if (!IsPamphletOpen)
        {
            CheckSelectedPamphlet();
        }
        else
            return;
    }
}
