using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transition1 : StateMachineBehaviour
{

    [SerializeField] private AudioClip combo1;
        [SerializeField] private AudioClip combo2;


    PlayerMovement playerMovement;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SoundEffectManager.instance.SkillCLip(combo1 , animator.transform , 1f);

        Debug.Log("Atttack Anim");


        playerMovement = animator.GetComponent<PlayerMovement>();

        if (playerMovement != null)
        {
            playerMovement.enabled = false;
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
        if(PlayerCombat.instance.isAttacking)
        {


            PlayerCombat.instance.charanim.Play("mainattack2");
                SoundEffectManager.instance.SkillCLip(combo2 , animator.transform , 1f);


        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
         Debug.Log("Attack Anim Ended");

            if(playerMovement !=null)
            {
                playerMovement.enabled = true;
            }


        PlayerCombat.instance.isAttacking = false;

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
