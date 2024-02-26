using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator charanim;
    public bool isAttacking = false;
    public static PlayerCombat instance;



    private void Awake()
    {
       instance = this;
    }

   void Start()
    {
        charanim = GetComponent<Animator>();
    }


    private void Update()
    {
        Attack();
    }

    void Attack()
    {
        if(Input.GetKeyDown(KeyCode.Z)&& !isAttacking)
        {
            isAttacking = true;
        }
    }

}
