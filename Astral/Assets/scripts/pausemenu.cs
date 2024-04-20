using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class pausemenu : MonoBehaviour
{

    private bool isPaused = false;
    private float originalTimeScale = 1f;

    // Update is called once per frame

    void Start()
    {
        originalTimeScale = Time.timeScale;

    }
    void Update()

     {
     }
    public void TogglePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0f;
        }
    }
    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;

    }
    
}
