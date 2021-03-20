using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    Inventory Inventory;

    private int slotIndex;

    void Start()
    {
        Inventory = GameObject.Find("Player").GetComponent<Inventory>();
        slotIndex = int.Parse(gameObject.name.Substring(gameObject.name.IndexOf("_") + 1));
    }

    private void Update()
    {
        if (transform.childCount <= 0)
        {
            Inventory.Slots[slotIndex].IsEmpty = true;
        }
    }
}
