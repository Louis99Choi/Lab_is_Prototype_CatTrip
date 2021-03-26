using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectMap : MonoBehaviour,  IPointerClickHandler
{
    [SerializeField]
    public MapIndex MapName;


    void Start()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        MapManager.Instance.SelectedMap = MapName;
    }
}
