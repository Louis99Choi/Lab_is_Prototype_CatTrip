using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PamphletClose : MonoBehaviour
{
    public MapIndex MapName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClosePamphlet()
    {
        int iCount = GameObject.Find("Canvas").transform.Find("Back").transform.childCount;
        for (int i = 0; i < iCount; i++)
        {
            GameObject.Find("Canvas").transform.Find("Back").transform.Find("Pamphlet" + i.ToString()).gameObject.SetActive(false);
        }
        SelectPamphlet.IsPamphletOpen = false;
    }    
}
