using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FCLoader : MonoBehaviour
{
    public float wait_seconds;
    public int nextscene;
    void Start()
    {
        StartCoroutine(Wait_for_intro());
    }

    IEnumerator Wait_for_intro()
    {
        yield return new WaitForSeconds(wait_seconds);
        SceneManager.LoadScene(nextscene);

        if (wait_seconds == 30)
        {
            Destroy(gameObject);
        }
    }

   
    void Update()
    {

    }
}
