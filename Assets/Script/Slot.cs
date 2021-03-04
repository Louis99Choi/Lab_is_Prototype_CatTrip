using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    Inventory Inventory;
    public int num;

    void Start()
    {
        Inventory = GameObject.Find("Player").GetComponent<Inventory>();
        num = int.Parse(gameObject.name.Substring(gameObject.name.IndexOf("_") + 1));
    }

    private void Update()
    {
        if (transform.childCount <= 0)
        {
            Inventory.Slots[num].IsEmpty = true;
        }
    }
}
