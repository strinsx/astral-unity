using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class zz : MonoBehaviour
{
    
       public void Mainmenutest()
    {
        SceneManager.LoadSceneAsync(0);
        
    }

    public void Settings()
    {
        SceneManager.LoadSceneAsync(1);

    }
       public void Startgame()
    {
        SceneManager.LoadSceneAsync(2);
        
    }   

    public void Loading() { 
    
        SceneManager.LoadSceneAsync(4);
    }

    public void GameInformation()
    {
        SceneManager.LoadSceneAsync(5);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

}
