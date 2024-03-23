using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;


public class BossEnrageAttack : MonoBehaviour
{
    public int damage;
    Animator anim;
    PlayerHealthRafales playerhealth;
    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;
    public int attackDamage = 20;




    private void Start()
    {
        anim = GetComponent<Animator>();
        playerhealth = FindObjectOfType<PlayerHealthRafales>();
    }

    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.forward * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);

        if (colInfo != null)
        {
            colInfo.GetComponent<PlayerHealthRafales>();
            if (playerhealth != null)
            {
                playerhealth.TakeDamage(attackDamage);
            }
        }
    }

    public void EnrangedAttack()
    {

    }
}