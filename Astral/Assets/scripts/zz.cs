using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class zz : MonoBehaviour
{
    
       public void Newmainmeny()
    {
        SceneManager.LoadSceneAsync(0);
        
    }

    public void NewSettings()
    {
        SceneManager.LoadSceneAsync(1);

    }
        public void GameInformation()
    {
        SceneManager.LoadSceneAsync(2);
    }
       public void Firstmap()
    {
        SceneManager.LoadSceneAsync(3);
        
    }   
       public void secondmap(){
        SceneManager.LoadSceneAsync(4);
       }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

}
