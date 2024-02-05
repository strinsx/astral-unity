using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraFollowRafales : MonoBehaviour {

    public Vector3 offset;
    public float smoothSpeed = 0.125f;
    public Transform player;

    void Update()
    {
        Vector3 Desiredpos = player.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, Desiredpos, smoothSpeed);
        transform.position = smoothedPos;

    }

}
