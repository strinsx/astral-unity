using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteRun : StateMachineBehaviour


{

    public float speed = 1f;
    Transform player;
    Rigidbody2D rb;
    MinionFlip minion;
    public float attackRange = 10f;
    public float attakcDistance = 2f;
    public GameObject projectilePrefab;
    public float bulletSpeed = 1f;


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

        Vector3 direction = (player.position - (Vector3)rb.position).normalized;

        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newpos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newpos);

        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {

            GameObject bullet = Instantiate(projectilePrefab, rb.position, Quaternion.identity);

            bullet.transform.right = direction;


            animator.SetTrigger("Attack");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
