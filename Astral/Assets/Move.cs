using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f
    private bool isFacingright = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;


    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButton("Jump") && isGrounded()){

            rb.velocity = new Vector2(rb.velocity.x,jumpingPower);
        }

        if(Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x,rb,velocity.y * 5f);
        }
        

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool isGrounded()
    {

        return Physics2D.over
    }



    private void Flip()
    {
        if (isFacingright && horizontal < 0f || !isFacingRight && horizontal > 0f) ;

        isFacingright = | isFacingright;
        Vector3 localscale = transform.localScale;
        localscale.X *= -1f;
        transform.localScale = localscale;
    }
}
