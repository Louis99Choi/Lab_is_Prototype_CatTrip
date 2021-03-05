using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exchange : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Exchange"))
        {
            GameManager.TotalPoint += GameManager.tmpPoint;
            GameManager.tmpPoint = 0;

            for (int i = 0; i < Inventory.Instance.MaxSlot; i++)
            {
                if (Inventory.Instance.Slots[i].IsEmpty)
                    return;

                else
                    Destroy(GameObject.Find("Slot_" + i).transform.GetChild(0).gameObject);
            }

        }
    }
}

