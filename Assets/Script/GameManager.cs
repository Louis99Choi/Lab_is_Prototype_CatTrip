using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float CurrentTime;
    public Text GameTimeText;
    
    public GameObject Background;

    private void Start()
    {
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
