using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    float HorizontalInput;
    float Speed = 15f;
    bool isFlipped = true;
    float jump = 4f;
    bool isGrounded = false;
    Animator animator;
    Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        horizontal = Input.GetAxis("Horizontal");

        body.velocity = new Vector2(speed * horizontal, body.velocity.y);
        animator.SetBool("isJumping", true);
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        PixelFlip();
        if(Input.GetButtonDown("Jump")  && !isGrounded)
        {
            body.velocity = new Vector2(body.velocity.x, jump);
            isGrounded = false;
            animator.SetBool("ifJumping", !isGrounded);
            body.AddForce(new Vector2(body.velocity.x, jump));
        }
    }

    private void FixedUpdate()
    public void migsLanding()
    {
        animator.SetBool("isJumping", false);
    }

    public void PixelFlip()
    {
        body.velocity = new Vector2(HorizontalInput * Speed, body.velocity.y);
        animator.SetFloat("xVelocity", Math.Abs(body.velocity.x));
        animator.SetFloat("yVelocity",(body.velocity.y));

    }

    void PixelFlip()
    {
        if (isFlipped && HorizontalInput < 0f || !isFlipped && HorizontalInput > 0f)
        {
            isFlipped = !isFlipped;
            Vector3 Scales = transform.localScale;
            Scales.x *= -1f;
            transform.localScale = Scales;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
        animator.SetFloat("yVelocity", (body.velocity.x));

    }
}
