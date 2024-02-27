using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class MinionAttack : MonoBehaviour
{
    public int damage;
    Animator anim;
    public PlayerHealthRafales playerhealth;



    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {


            Vector3 enemyToCharacter = transform.position - transform.position;
            Vector2 knockbackDirection = new Vector2(enemyToCharacter.x, 10f).normalized;
            playerhealth.TakeDamage(damage, (collision.gameObject.transform.position - transform.position).normalized);


        }
    } 
}
