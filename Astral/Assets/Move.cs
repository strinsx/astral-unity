using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float horizontal;
    private float speed = 500f;
    private float jumpingPower = 1000f;
    private bool isFacingright = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;


    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

       if (Input.GetButtonDown("Jump") && Nasaground())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

       if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 500f) ;
                
        }
            Jumpflip();
        
        

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool Nasaground()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }


    private void Jumpflip()
    {

        if (isFacingright &&  horizontal < 0f || !isFacingright && horizontal > 0f)
        {
            isFacingright = !isFacingright;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
