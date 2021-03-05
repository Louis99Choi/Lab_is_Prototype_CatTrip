﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public GameObject Describing;
    public GameObject SlotItem;
    public ItemIndex ItemName;
    public GameObject Player;

    void Start()
    {
        Player = GameObject.Find("Player");
        float Rx = UnityEngine.Random.Range(-100.0f, 100.0f);
        float Ry = UnityEngine.Random.Range(-100.0f, 100.0f);
        Vector3 vec = new Vector3(Rx, Ry, 0);
        transform.position = vec;
    }

    // Update is called once per frame
    void Update()
    {
        GetItem(ItemName);

    }

    private void GetItem(ItemIndex itemName)
    {
        if (Time.timeScale > 0.0f && Describing.activeSelf == true && Input.GetKeyDown(KeyCode.E))
        {
            GameManager.tmpPoint += GameManager.ItemList[(int)itemName].ItemPoint;

            Inventory Inven = Player.GetComponent<Inventory>();
            for (int i = 0; i < Inven.Slots.Count; i++)
            {
                if (Inven.Slots[i].IsEmpty)
                {
                    Instantiate(SlotItem, Inven.Slots[i].SlotObj.transform, false);
                    Inven.Slots[i].IsEmpty = false;
                    Destroy(gameObject);
                    break;
                }
            }

        }
        else
        {
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Describing.SetActive(true);

        }
        else
        {
            return;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)  
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Describing.SetActive(false);
        }
        else
        {
            return;
        }
    }
}
