using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public GameManager V;
    // Start is called before the first frame update
    void Start()
    {
        float Rx = UnityEngine.Random.Range(0.0f, 100.0f);
        float Ry = UnityEngine.Random.Range(0.0f, 100.0f);
        Vector3 vec = new Vector3(Rx, Ry, 0);
        transform.position = vec;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
