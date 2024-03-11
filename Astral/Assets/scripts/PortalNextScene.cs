using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalNextScene : MonoBehaviour
{
    public int sceneBuildIndex;
    public SceneFader sceneFader;

    private void Start()
    {
        sceneFader = FindObjectOfType<SceneFader>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            sceneFader.FadeToScene(sceneBuildIndex);
        }
    }
}
