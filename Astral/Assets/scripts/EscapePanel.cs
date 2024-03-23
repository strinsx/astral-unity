using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EscapePanel : MonoBehaviour
{
    private bool isPaused = false;

    public GameObject Escape;
    public GameObject Background;
    // Start is called before the first frame update
    void Start()
    {
        Escape.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Background.SetActive(true);
                Escape.SetActive(true);
                isPaused = true;
                Time.timeScale = 0;
            }
            else
            {
                Background.SetActive(false);
                Escape.SetActive(false);
                isPaused = false;
                Time.timeScale = 1;
            }

        }
        }
}
