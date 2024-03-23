using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class pausemenu : MonoBehaviour
{

    private bool isPaused = false;

    // Update is called once per frame
    
    void Start()
    {
  
    }
    void Update()

     {
     }
    public void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
    }
    public void ResumeGame()
    {
            isPaused = false;
            Time.timeScale = 1;

        }
    
}
