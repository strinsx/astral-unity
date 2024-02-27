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

        foreach (Collider2D enemyGameobject in enemy)
        {
            Debug.Log("HIT ENEMY");
            enemyGameobject.GetComponent<MinionHealth>().health -= 10;
        }

        } 

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackpoint.transform.position, radius);
    }

}
