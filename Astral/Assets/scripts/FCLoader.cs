using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FCLoader : MonoBehaviour
{
    public float wait_seconds;
    public Animator musicAnim;
    void Start()
    {
        StartCoroutine(Wait_for_intro());
    }

    IEnumerator Wait_for_intro()
    {
        musicAnim.SetTrigger("fadeOut");
        yield return new WaitForSeconds(wait_seconds);
        SceneManager.LoadScene(5);
    }

   
    void Update()
    {

    }
}
