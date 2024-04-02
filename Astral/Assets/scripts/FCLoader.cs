using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FCLoader : MonoBehaviour
{
    public float wait_seconds;
    public Animator musicAnim;
    public AudioSource deleteaudioCutscene;
    void Start()
    {
        StartCoroutine(Wait_for_intro());
    }

    IEnumerator Wait_for_intro()
    {
        musicAnim.SetTrigger("fadeOut");
        yield return new WaitForSeconds(wait_seconds);
        SceneManager.LoadScene(5);

        if (wait_seconds == 40)
        {
            Destroy(gameObject);
            deleteaudioCutscene.Stop();
        }
    }

   
    void Update()
    {

    }
}
