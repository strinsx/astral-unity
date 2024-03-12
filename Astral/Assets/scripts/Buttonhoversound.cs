using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Buttonhoversound : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public AudioSource hoverSound;

    void Start()
    {
        // Get the AudioSource component
        if (hoverSound == null)
            hoverSound = GetComponent<AudioSource>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Play sound when cursor enters the button area
        if (hoverSound != null && !hoverSound.isPlaying)
            hoverSound.Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Stop sound when cursor exits the button area
        if (hoverSound != null && hoverSound.isPlaying)
            hoverSound.Stop();
    }
}
