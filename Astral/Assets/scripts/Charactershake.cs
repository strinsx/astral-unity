using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactershake : MonoBehaviour
{
 public LandCameraShake cameraShake;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            cameraShake.ShakeCamera();
        }
    }
}
