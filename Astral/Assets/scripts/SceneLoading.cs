using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{
    public GameObject LoaderUI;
    public Slider progressSlider;
    public Animator musicAnim;


    public void StartGame()
    {
        LoadSceneWithDelay(13, 5f);
    }

    public void LoadSceneWithDelay(int index, float delay)
    {
        StartCoroutine(LoadSceneWithDelay_Coroutine(index, delay));
    }

    IEnumerator LoadSceneWithDelay_Coroutine(int index, float delay)
    {
        // Show loader UI
        LoaderUI.SetActive(true);

        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Load the scene asynchronously
        StartCoroutine(LoadScene_Coroutine(index));
    }

    // Coroutine to load scene asynchronously
    IEnumerator LoadScene_Coroutine(int index)
    {
        // Reset progress slider value
        progressSlider.value = 0;

        // Load scene asynchronously
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);
        asyncOperation.allowSceneActivation = false;

        // Loop until scene is fully loaded
        while (!asyncOperation.isDone)
        {
            // Update progress slider value
            progressSlider.value = asyncOperation.progress / 0.9f; // Normalize progress

            // Check if loading progress is almost complete
            if (asyncOperation.progress >= 0.9f)
            {
                // Set progress slider to maximum value
                progressSlider.value = 1;

                // Allow scene activation
                asyncOperation.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
