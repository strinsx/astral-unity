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
        public void credits(){
        SceneManager.LoadSceneAsync(2);
    }
        public void GameInformation()
    {
        SceneManager.LoadSceneAsync(3);
    }
       public void Firstmap()
    {
        AudioManager.instance.DestroyAudioManager();
        SceneManager.LoadSceneAsync(4);
        
    }   
       public void secondmap(){
        SceneManager.LoadSceneAsync(5); 
       }
    public void Fcutscene()
    {
        SceneManager.LoadSceneAsync(7);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

}
