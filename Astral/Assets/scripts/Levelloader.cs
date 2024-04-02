using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levelloader : MonoBehaviour
{
    public Animator transition;
    public float time = 0.5f;

    // Update is called once per frame
    void Update()
    {
    } 
    public void Loadnextlevel()
    {
        StartCoroutine(LoadLeveL(SceneManager.GetActiveScene().buildIndex + 1));
    }
    IEnumerator LoadLeveL(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(levelIndex);  
    }
}
