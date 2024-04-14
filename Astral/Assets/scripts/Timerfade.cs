using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timerfade : MonoBehaviour
{
    public Animator animator;
    public GameObject transitionfader;
    public float waitTime = 2f;

    public void OnButtonPress()
    {
        animator.SetBool("Pressed", true);

        StartCoroutine(DeactivateObjectAfterDelay());
    }

    private IEnumerator DeactivateObjectAfterDelay()
    {
        yield return new WaitForSeconds(waitTime);

        transitionfader.SetActive(false);
    }
}
