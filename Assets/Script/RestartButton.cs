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
        /*switch (DataManager.currentMapindex)
        {
            case MapIndex.FirstMap:
                { SceneManager.LoadScene("FirstMapSCN"); Time.timeScale = 1.0f; break; }
            case MapIndex.SecondMap:
                { SceneManager.LoadScene("SecondMapSCN"); Time.timeScale = 1.0f; break; }
        }*/

        /*if (DataManager.currentMapindex == (int)MapIndex.FirstMap)
        {
            SceneManager.LoadScene("FirstMapSCN");
            Time.timeScale = 1.0f;
        }
        else if (DataManager.currentMapindex == (int)MapIndex.FirstMap)
        {
            SceneManager.LoadScene("SecondMapSCN");
            Time.timeScale = 1.0f;
        }*/

    }

}
