using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class zz : MonoBehaviour
{
    
       public void StartGame()
    {
        SceneManager.LoadSceneAsync(1);
        
    }

    public void Settings()
    {
        SceneManager.LoadSceneAsync(3);

    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
