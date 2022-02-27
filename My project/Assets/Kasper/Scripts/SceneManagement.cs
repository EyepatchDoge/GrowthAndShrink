using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{

  public void ChangeScene(string sceneName)
    {
     
        SceneManager.LoadScene(sceneName);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void PlayGame()
    {
        Time.timeScale = 1;
    }
}
