using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorpoint : MonoBehaviour
{
    public AudioSource cursorPointAudio;

    void Start()
    {
        if (cursorPointAudio == null)
        {
            cursorPointAudio = gameObject.GetComponent<AudioSource>();
            if (cursorPointAudio == null)
            {
                cursorPointAudio = gameObject.AddComponent<AudioSource>();
            }
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {  PlayCursorPointSound();
        }
    }

    void PlayCursorPointSound()
    {
        if (cursorPointAudio.clip != null)
        {
            cursorPointAudio.Play();
        }
        else
        {
            Debug.LogError("No audio clip assigned to the AudioSource.");
        }
    }
}