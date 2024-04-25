using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Triggeringvibrationsounds : MonoBehaviour
{
    public float vibrationDuration = 0.5f;
    public float vibrationIntensity = 0.5f;
    public AudioSource audioSource;

    private Gamepad gamepad;

    void Start()
    {
        // Find the currently connected gamepad
        if (Gamepad.current != null)
        {
            gamepad = Gamepad.current;
        }
        else
        {
            Debug.LogWarning("No gamepad found.");
        }
    }

    public void TriggerVibrationWithSound()
    {
        // Check if gamepad is null
        if (gamepad != null)
        {
            // Trigger vibration
            gamepad.SetMotorSpeeds(vibrationIntensity, vibrationIntensity);
            Invoke("StopVibration", vibrationDuration);
        }
        else
        {
            Debug.LogWarning("No gamepad found.");
        }

        // Play sound effect
        if (audioSource != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("No AudioSource assigned.");
        }
    }

    void StopVibration()
    {
        // Check if gamepad is null
        if (gamepad != null)
        {
            // Stop vibration
            gamepad.SetMotorSpeeds(0, 0);
        }
        else
        {
            Debug.LogWarning("No gamepad found.");
        }
    }
}
