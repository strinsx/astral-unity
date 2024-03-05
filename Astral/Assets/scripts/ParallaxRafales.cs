using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxRafales : MonoBehaviour
{
    private float lenght, startpos;
    public GameObject cam;
    public float parallaxSpeed;

   void Start()
    {
        startpos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }


     void FixedUpdate()
    {

        float temp = (cam.transform.position.x * (1 - parallaxSpeed)); 
        float dist = (cam.transform.position.x * parallaxSpeed);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (temp > startpos + lenght) startpos += lenght;
        else if (temp < startpos - lenght) startpos -= lenght;

    }


}
