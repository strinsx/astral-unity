using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboAttackSound : MonoBehaviour
{
        public AudioSource audioSource;
    public AudioClip jumpSound;
    public AudioClip attackSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Example method for jumping
    public void Jump()
    {
        if (jumpSound != null)
        {
            audioSource.clip = jumpSound;
            audioSource.Play();
        }

        // Your jump logic here
    }

    // Example method for attacking
    public void Attack()
    {
        if (attackSound != null)
        {
            audioSource.clip = attackSound;
            audioSource.Play();
        }

        // Your attack logic here
    }
}

