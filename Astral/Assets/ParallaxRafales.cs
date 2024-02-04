using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxRafales : MonoBehaviour
{
    public Camera cam;
    public Transform subject;

    Vector2 startpos;
    float startZ;
    float distanceFromsub => transform.position.z - subject.position.z;
    float clippingplane => (cam.transform.position.z + (distanceFromsub > 0 ? cam.farClipPlane : cam.nearClipPlane));
    float parallaxFactor => Mathf.Abs(distanceFromsub) / clippingplane;
    Vector2 travel => (Vector2)cam.transform.position - startpos;

    public void Start()
    {
      startpos = transform.position;
        startZ = transform.position.z;
    }

    public void Update()
    {
        Vector2 newPos = transform.position = startpos + travel * 0.9f;
        transform.position = new Vector3(newPos.x, newPos.y, startZ);

    }


}
