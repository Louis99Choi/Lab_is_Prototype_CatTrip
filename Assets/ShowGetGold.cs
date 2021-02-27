using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowGetGold : MonoBehaviour
{
    private const string F = "Finished Game!\n +";
    private const string B = " Gold!";
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = F + (50 * GameManager.TotalPoint) + B;
    }
}
