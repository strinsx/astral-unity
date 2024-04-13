using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MinionRun : StateMachineBehaviour
   
{
    
    public float speed = 1f;
    public AudioClip idleSound;
    private AudioSource audioSource;
    Transform player;
    Rigidbody2D rb;
    MinionFlip minion;
    public float attackRange = 10f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        minion = animator.GetComponent<MinionFlip>();
        audioSource = animator.GetComponent<AudioSource>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        minion.Update();

        
            Vector2 target = new Vector2(player.position.x, rb.position.y);
            Vector2 newpos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            rb.MovePosition(newpos);


            if(audioSource == null)
            {
            audioSource = animator.gameObject.AddComponent<AudioSource>();
            }

            if (Vector2.Distance(player.position, rb.position) <= attackRange)
            {
             animator.SetTrigger("Attack");

            }
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }



}
