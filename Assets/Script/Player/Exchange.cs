using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exchange : MonoBehaviour
{

    private void Start()
    {

    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject Inv_Milk = GameObject.Find("Inv_Milk(Clone)"); 
        GameObject Inv_Fish = GameObject.Find("Inv_Fish(Clone)");

        if (collision.gameObject.CompareTag("Exchange"))
        {
            if (null != Inv_Milk) 
            {
                Destroy(Inv_Milk);
                GameManager.TotalPoint += 1;
            }
            else if (null != Inv_Fish)
            {
                Destroy(Inv_Fish);
                GameManager.TotalPoint += 2;
            }
            else
            {
                return;
            }                      
        }
    }
}

