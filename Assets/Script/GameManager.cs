using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum ItemPoint : int
{
    Fish = 1, Milk = 2, K2C1 = 3, Guitar = 4
} 

public class GameManager : MonoBehaviour
{
    public static int TotalPoint;

    public float CurrentTime;
    public Text GameTimeText;
    public GameObject Background;

    private void Start()
    {
        TotalPoint = 0;
        Time.timeScale = 1;
    }
    void Update()
    {
        if (CurrentTime > 0.0f)
        {
            CurrentTime -= Time.deltaTime;
            GameTimeText.text = "" + (int)CurrentTime;
        }

        else/* if (CurrentTime =< 0.0f)*/
        {
            Background.SetActive(true);
            GameTimeText.text = "게임종료";
            Time.timeScale = 0.0f;
        }
        
    }
}

[System.Serializable]
public class SlotData
{
    public bool IsEmpty;
    public GameObject SlotObj;
}
