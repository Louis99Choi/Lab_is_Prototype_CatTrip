using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    public List<SlotData> Slots = new List<SlotData>();
    public int MaxSlot = 4;
    public GameObject SlotPrefab;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != null)
        {
            return;
        }
    }

    private void Start()
    {
        GameObject SlotPanel = GameObject.Find("Panel");

        for (int i = 0; i < MaxSlot; i++)
        {
            GameObject Go = Instantiate(SlotPrefab, SlotPanel.transform, false);
            Go.name = "Slot_" + i;
            SlotData Slot = new SlotData(true, Go);
            Slots.Add(Slot);
        }
    }

}

