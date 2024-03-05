using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LandCameraShake : MonoBehaviour
{
    public Transform cameraTransform; // Reference to the camera's transform
    public float shakeDuration = 0.5f; // Duration of the shake
    public float shakeAmount = 0.7f; // Intensity of the shake
    public float decreaseFactor = 1.0f; // Rate at which the shake decreases

    Vector3 originalPos; // Original position of the camera

    void Start()
    {
        originalPos = cameraTransform.localPosition;
    }

    public void ShakeCamera()
    {
        if (cameraTransform != null)
        {
            originalPos = cameraTransform.localPosition;
            InvokeRepeating("DoShake", 0, 0.01f);
            Invoke("StopShake", shakeDuration);
        }
    }

    void DoShake()
    {
        if (shakeDuration > 0)
        {
            cameraTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0;
            cameraTransform.localPosition = originalPos;
        }
    }

    void StopShake()
    {
        CancelInvoke("DoShake");
        cameraTransform.localPosition = originalPos;
    }
}