using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public float fadeDuration = 1f;
    public Image fadeOverlay;

    private void Start()
    {
        StartCoroutine(FadeIn());

    }

    public void FadeToScene(int sceneBuildIndex)
    {
        StartCoroutine(FadeOut(sceneBuildIndex));
    }

    IEnumerator FadeOut(int sceneBuildIndex)
    {
        float timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Clamp01(timer / fadeDuration);
            fadeOverlay.color = new Color(0f, 0f, 0f, alpha);
            yield return null;
        }

        SceneManager.LoadScene(sceneBuildIndex);
    }

    IEnumerator FadeIn()
    {
        float timer = fadeDuration;

        while (timer > 0f)
        {
            timer -= Time.deltaTime;
            float alpha = Mathf.Clamp01(timer / fadeDuration);
            fadeOverlay.color = new Color(0f, 0f, 0f, alpha);
            yield return null;
        }
    }
}
