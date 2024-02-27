using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionHealth : MonoBehaviour
{
    public float health;
    public float currenthealth;
    private Animator anim;
    private bool attacked;
    private float despawnae = 2f;
    public AnimationClip main_death;
    public Animation animationcomponent;
    private void Start()
    {
        anim = GetComponent<Animator>();
        currenthealth = health;
       

  

    }


    private void Update()
    {
       
        hit();

    }


    private void hit()
    {
        if (health < currenthealth)
        {
            currenthealth = health;
            anim.SetTrigger("Attacked");

            
            
        }

        if (health <= 0)
        {
            anim.SetBool("isDead", true);
            Debug.Log("EnemyDead");

            StartCoroutine(DestroyGameob());
        }
   

    }

    IEnumerator DestroyGameob()
    {
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);

        yield return new WaitForSeconds(despawnae);

        Destroy(this.gameObject);
    }



}
