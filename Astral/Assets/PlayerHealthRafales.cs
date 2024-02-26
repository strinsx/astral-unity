using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthRafales : MonoBehaviour
{

    public int maxHealth = 50;
    public int currentHealth;
    public HealthBar healthBar;
    private bool isDead;
    public GameManagerScript gameManager;
    
    //public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
        Alive();
    }

    public void Alive()
    {
        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            gameManager.gameOver();
            //animator.SetBool("Die", true);
        }
    }
}
