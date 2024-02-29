using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;

public class DashMoveRafales : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float startDash;
    private int direction;
    private Animator animator;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        dashTime = startDash;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(direction == 0)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                direction = 1;

            } else if (Input.GetKeyDown(KeyCode.Q))
            {
                direction= 2;
                animator.SetTrigger("Dash");
            }
        }else
        {
            if(dashTime <= 0)
            {
                direction = 0;
                dashTime = startDash;
                rb.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;
                if (direction == 1)
                {
                    rb.velocity = Vector2.left * dashSpeed;
                } else if(direction == 2)
                {
                    rb.velocity = Vector2.right * dashSpeed;
                }
            }
        }
    }
}
