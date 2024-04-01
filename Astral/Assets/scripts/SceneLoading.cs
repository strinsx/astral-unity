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
 
    public void LoadScene(int index)
    {
        StartCoroutine(LoadScene_Coroutine(index));
    }
 
    public IEnumerator LoadScene_Coroutine(int index)
    {
        progressSlider.value = 0;
        LoaderUI.SetActive(true);
 
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(1);
        asyncOperation.allowSceneActivation = false;
 
        while (!asyncOperation.isDone)
        {
            progressSlider.value = asyncOperation.progress;

            if(asyncOperation.progress >= 0.9f)
            {
                progressSlider.value = 1;

                asyncOperation.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
