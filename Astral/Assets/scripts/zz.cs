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
       public void FirstMapAstral()
    {
        DestroyAudioManagerExist();
        SceneManager.LoadSceneAsync(4);
        
    }   
       public void FirstBossMap(){

        DestroyAudioManagerExist();
        SceneManager.LoadSceneAsync(5); 
       }
    public void SecondMapBellum()
    {
        AudioManager.instance.DestroyAudioManager();
        SceneManager.LoadSceneAsync(6);
    }
    public void SecondBossMap()
    {
        AudioManager.instance.DestroyAudioManager();
        SceneManager.LoadSceneAsync(7);
    }
    public void ThirdMapRhaast()
    {
        AudioManager.instance.DestroyAudioManager();
        SceneManager.LoadSceneAsync(8);
    }
    public void ThirdBossMap()
    {
        DestroyAudioManagerExist();
        SceneManager.LoadSceneAsync(9);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    private void DestroyAudioManagerExist() {
    
        if(AudioManager.instance != null)
        {
            AudioManager.instance.DestroyAudioManager();
        }
    
    }

}
