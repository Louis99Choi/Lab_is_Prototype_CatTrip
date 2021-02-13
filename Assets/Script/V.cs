using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V : MonoBehaviour
{
    public GameObject Item;
    Vector3 vec = new Vector3(0,5,0);
    // Start is called before the first frame update
    void Start()
    {
        transform.position = Item.transform.position + vec;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Item.transform.position + vec;
    }
}
