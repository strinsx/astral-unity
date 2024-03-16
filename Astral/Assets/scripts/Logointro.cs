using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logointro : MonoBehaviour
{
    public float wait_seconds;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait_for_intro());
    }

    IEnumerator Wait_for_intro()
    {
        yield return new WaitForSeconds(wait_seconds);
        SceneManager.LoadScene(0);      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
