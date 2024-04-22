using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicTransition : MonoBehaviour
{
    private static MusicTransition instance;

    public int stopSceneBuildIndex;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == stopSceneBuildIndex)
        {
             Destroy(gameObject);
        }
    }
}
