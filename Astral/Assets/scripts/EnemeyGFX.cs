using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeyGFX : MonoBehaviour
{
    public AIPath aiPath;
    void Start()
    {
        
    }

    void Update()
    {
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(5f, 5f, 5f);
        } else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(5f, 5f, 5f);
        }
    }
}
