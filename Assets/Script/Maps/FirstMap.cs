using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstMap : MonoBehaviour
{
    public GameObject Background;
    // Start is called before the first frame update
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

    public void OnMouseDown()
    {
        Background.SetActive(true);
    }
}
