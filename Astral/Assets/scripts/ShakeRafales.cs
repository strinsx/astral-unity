using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeRafales : MonoBehaviour
{
    public Animator camanim;
    public void camShake()
    {
        camanim.SetTrigger("shake");
    }
}
