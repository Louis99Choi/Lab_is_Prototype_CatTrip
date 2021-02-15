using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V : MonoBehaviour
{
    public GameObject Item;
    public static V instanceee;
    Vector3 vec = new Vector3(0,5,0);
    // Start is called before the first frame update

/*    private void Awake()
    {
        if (instanceee == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instanceee = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }*/
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
