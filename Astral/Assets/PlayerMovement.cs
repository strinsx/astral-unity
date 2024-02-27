using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    public Animator animator;
    private bool djump;
    bool isjuumping;
    private KnockBackMainRafales knockback;
    private bool isKnockedBack;




    // Start is called before the first frame update
    void Start()
    {
       knockback  = GetComponent<KnockBackMainRafales>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isKnockedBack)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

            if (Input.GetButtonDown("Jump"))
            {


                jump = true;
                animator.SetBool("isJumping", true);
            }
        }
        
    }

    void FixedUpdate()
    {
        if (!isKnockedBack)
        {

            controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
            jump = false;
        }
    }

    public void Onland()
    {
        animator.SetBool("isJumping", false);
    }

    public void StartKnockback()
    {
        isKnockedBack = true;
    }

    public void EndKnockBack()
    {
        isKnockedBack = false;
    }
   

}
