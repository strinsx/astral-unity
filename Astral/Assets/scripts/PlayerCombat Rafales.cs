using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator charanim;
    public bool isAttacking = false;
    public static PlayerCombat instance;
    public GameObject attackpoint;
    public float radius;
    public LayerMask enemies;
    public float KBForce = 5;

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


    public void z() {

        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackpoint.transform.position, radius, enemies);

        foreach (Collider2D enemyCollider in enemy)
        {
            Debug.Log("HIT ENEMY");
            Rigidbody2D enemyRigidbody = enemyCollider.gameObject.GetComponent<Rigidbody2D>();
            if (enemyRigidbody != null)
            {
                // Determine knockback direction based on relative position of enemy to player
                Vector2 knockbackDirection = (enemyRigidbody.position - GetComponent<Rigidbody2D>().position).normalized;
                enemyRigidbody.AddForce(knockbackDirection * KBForce, ForceMode2D.Impulse);
            }

            enemyCollider.GetComponent<MinionHealth>().health -= 10;
        }
    } 

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackpoint.transform.position, radius);
    }

}
