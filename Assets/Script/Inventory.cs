using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    public List<SlotData> Slots = new List<SlotData>();
    private int MaxSlot = 4;
    public GameObject SlotPrefab;

    private void Start()
    {
        GameObject SlotPanel = GameObject.Find("Panel");

        for (int i = 0; i < MaxSlot; i++)
        {
            GameObject Go = Instantiate(SlotPrefab, SlotPanel.transform, false);
            Go.name = "Slot_" + i;
            SlotData Slot = new SlotData();
            Slot.IsEmpty = true;
            Slot.SlotObj = Go;
            Slots.Add(Slot);
        }
    }
}
