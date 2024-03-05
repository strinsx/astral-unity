using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCollider : MonoBehaviour
{
    private bool collidedWithEnemy = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyCollider"  && !collidedWithEnemy)
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), collision.collider, true);
            collidedWithEnemy = true;
            Debug.Log("Yung Main naka collide sa enemy");
        }
        }
}
