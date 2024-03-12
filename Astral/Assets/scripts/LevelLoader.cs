using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitiontime = 1f;

    void update(){
        if(Input.GetMouseButtonDown(0)){
            LoadNextLevel();
        }
    }
        public void LoadNextLevel(){
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex +1));
        }
    IEnumerator LoadLevel(int levelIndex){
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitiontime);
        SceneManager.LoadScene(levelIndex);

    }
    }
