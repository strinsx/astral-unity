using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float jump;
    public bool isFacingright = true;
    private float horizontal;
    public Rigidbody2D body;
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        body.velocity = new Vector2(speed * horizontal, body.velocity.y);
        animator.SetBool("isJumping", true);
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        PixelFlip();

        if(Input.GetButtonDown("Jump"))
        {
            body.AddForce(new Vector2(body.velocity.x, jump));

        }
    }

    public void migsLanding()
    {
        animator.SetBool("isJumping", false);
    }

    public void PixelFlip()
    {

        if(isFacingright && horizontal < 0f || !isFacingright && horizontal > 0f)
        {
            isFacingright = !isFacingright;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}

