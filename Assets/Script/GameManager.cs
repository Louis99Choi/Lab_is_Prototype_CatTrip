﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float CurrentTime;
    public Text GameTimeText;

    // Update is called once per frame
    void Update()
    {
        if (CurrentTime > 0.0f)
        {
            CurrentTime -= Time.deltaTime;
            GameTimeText.text = "" + (int)CurrentTime;
        }

        else/* if (CurrentTime < 0.0f)*/
        {
            GameTimeText.text = "게임종료";
            Time.timeScale = 0.0f;
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("CountDown");
                Time.timeScale = 1.0f;
            }
            else
                return;

        }
        
    }
}
