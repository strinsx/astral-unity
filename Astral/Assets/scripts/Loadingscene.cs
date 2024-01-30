using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loadingscene : MonoBehaviour
{
 public GameObject LoadingScreen;
 public Image Loadbar;

public void LoadScene(int sceneId)
{
    StartCoroutine(LoadSceneAsync(sceneId));
}
 IEnumerator LoadSceneAsync(int sceneId)
 {
    AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);
    LoadingScreen.SetActive(true);
    while (!operation.isDone)
    {
        float progress = Mathf.Clamp01(operation.progress / 0.9f);
        Loadbar.fillAmount = progress;

        yield return null;
    }
            yield return new WaitForSeconds(3); 
        LoadingScreen.SetActive(false);
 }
}