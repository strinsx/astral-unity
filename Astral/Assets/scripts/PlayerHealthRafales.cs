using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthRafales : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public bool alive;
    Animator animator;
    private KnockBackMainRafales knocback;
    public GameManagerScript gamemanager;
    private bool isDead;

    // Start is called before the first frame update

   
    void Start()
    {
        
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        knocback  = GetComponent<KnockBackMainRafales>();
        animator = GetComponent<Animator>();
        
    }

    private void Update()
    {

    }

    // Update is called once per frame
    public void TakeDamage(int damage, Vector2 hitDirection)
    {

      
        currentHealth -= damage;

        knocback.CallKnockback(hitDirection, Vector2.up, Input.GetAxisRaw("Horizontal"));

        healthBar.SetHealth(currentHealth);


        if (currentHealth <= 0 && !isDead)
        {

            animator.SetBool("Die", true);
            isDead = true;
            ///gamemanager.enabled = true;
            ////gamemanager.gameOver();
        }

        else 
        {
            animator.SetTrigger("Hit");
            
        }

    }

  
   
 
    
}
