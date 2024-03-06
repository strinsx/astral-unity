using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionFlip : MonoBehaviour
{
    GameObject player;

    public bool flip = true; 

    public void Start()
    {
        player = GameObject.Find("mainCharacter");
    }

    public void Update()
    {
        Vector3 scale = transform.localScale;


        if (player.transform.position.x > transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1 : 1);

        }
        else
        {
            scale.x = Mathf.Abs(scale.x) *  (flip ? -1 : 1);
        }

        transform.localScale = scale;

    }
}
