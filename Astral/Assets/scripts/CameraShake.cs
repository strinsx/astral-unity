using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // Reference to the main camera
    private Camera mainCamera;

    // Variables for controlling the shake effect
    public float shakeDuration = 0.1f;
    public float shakeAmount = 0.1f;

    Vector3 originalPosition;

    void Awake()
    {
        // Find the main camera in the scene
        mainCamera = Camera.main;

        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found. Make sure there is at least one camera in the scene.");
        }
    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            // Shake the camera
            mainCamera.transform.localPosition = originalPosition + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * 1.5f; // Adjust shake speed
        }
        else
        {
            shakeDuration = 0f;
            mainCamera.transform.localPosition = originalPosition;
        }
    }

    public void TriggerShake()
    {
        // Store the original camera position
        originalPosition = mainCamera.transform.localPosition;
        // Start the shake effect
        shakeDuration = 0.1f; // Adjust shake duration
    }
}
