using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    
    
    public void ChangeGameScene()
    {
        SceneManager.LoadScene(DataManager.MapList[(int)DataManager.currentMapindex].MapName);
        Time.timeScale = 1.0f;
        

    }

}
