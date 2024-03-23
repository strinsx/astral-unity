using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class Boss_Run : StateMachineBehaviour

{

    public float speed = 1f;
    Transform player;
    Rigidbody2D rb;
    MinionFlip minion;
    public float attackRange = 10f;
    public GameObject bullet;
    public GameObject bulletParent;
    public float bulletSpeed;
    public float rangebulletMultiplier;
    public float fireRate = 2f;
    private float nextFireTime = 0f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        minion = animator.GetComponent<MinionFlip>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        minion.Update();

        if (Time.time >= nextFireTime)
        {

            Vector2 target = new Vector2(player.position.x, rb.position.y);
            Vector2 newpos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            rb.MovePosition(newpos);

            if (Vector2.Distance(player.position, rb.position) <= attackRange)
            {
                animator.SetTrigger("Attack");

                GameObject newBullet = Instantiate(bullet, rb.position, Quaternion.identity);
                Vector2 direction = ((Vector2)player.position - (Vector2)rb.position).normalized;
                newBullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed * rangebulletMultiplier;

                nextFireTime = Time.time + 1f / fireRate;

                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                newBullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            }
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }



}
