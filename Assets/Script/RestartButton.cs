using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    
    
    public void ChangeGameScene()
    {
        if(DataManager.currentMapid == 0)
        {
            SceneManager.LoadScene("FirstMapSCN");
            Time.timeScale = 1.0f;
        }
        else if(DataManager.currentMapid == 1)
        {
            SceneManager.LoadScene("SecondMapSCN");
            Time.timeScale = 1.0f;
        }
        
    }

}
