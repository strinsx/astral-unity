using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject mainCharacter;
    public GameObject Menu;
    // Start is called before the first frame update
   /* void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        f (gameOverUI.activeInHierarchy)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else 
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }   */
    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void close()
    {
        Menu.SetActive(false);
    }
    /*public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("RESTART");
    }  */
    public void quit()
    {
        Application.Quit();
        Debug.Log("QUIT");
    }
}