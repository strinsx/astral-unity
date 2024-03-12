using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroygameobj : MonoBehaviour
{
    void Start()
    {
        // Subscribe to the scene loaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        // Unsubscribe from the scene loaded event
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Destroy the GameObject when a new scene is loaded
        Destroy(gameObject);
    }
}
