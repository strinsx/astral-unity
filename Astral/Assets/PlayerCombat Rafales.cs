using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{


    public Animator animatorattack;

    // Update is called once per frame
    void Update()


    {
        if (Input.GetKeyDown(KeyCode.V) || Input.GetMouseButtonDown(1)) { 

            Attack();
        
        }
    }

    void Attack()
    {

        animatorattack.SetTrigger("Attack");
    }
}
