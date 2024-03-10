using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Textdestroy : MonoBehaviour
{
    public float disappearDelay = 5f;
    private float timer = 0f;
    private bool isDisappearing = false;

    void Update()
    {
      
        timer += Time.deltaTime;

        if (timer >= disappearDelay && !isDisappearing)
        {
            isDisappearing = true;

            Destroy(gameObject);
        }
    }
}
