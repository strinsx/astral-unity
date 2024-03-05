using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject respawnPoint;
    public GameObject mainCharacter;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOverUI.activeInHierarchy)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else 
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }   
    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("restart");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("MainMenu");
    }
    public void Setting()
    {
        SceneManager.LoadScene("SETTINGS");
        Debug.Log("SETTINGS");
    }
}