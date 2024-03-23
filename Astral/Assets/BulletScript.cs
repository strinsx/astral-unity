using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    GameObject target;
    public float speed = 20f;
    public int damage = 0;
    Rigidbody2D bulletrb;
    private bool hasHit;

    private void Start()
    {
        bulletrb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        bulletrb.velocity = new Vector2(moveDir.x, moveDir.y);







        Destroy(this.gameObject, 2);
    }


    private void Update()
    {

        if (hasHit)
        
            return;
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, GetComponent<Rigidbody2D>().velocity.normalized, GetComponent<Rigidbody2D>().velocity.magnitude * Time.deltaTime);

        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {

            hasHit = true;
            PlayerHealthRafales playerHealth = hit.collider.gameObject.GetComponent<PlayerHealthRafales>();

          
            if (playerHealth != null)
            {
               
                playerHealth.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}
