using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCreditscene : MonoBehaviour
{
    public float wait_seconds;
    void Start()
    {
        StartCoroutine(Wait_for_intro());
    }

    IEnumerator Wait_for_intro()
    {
        yield return new WaitForSeconds(wait_seconds);
        SceneManager.LoadScene(0);
    }


    void Update()
    {

    }
}