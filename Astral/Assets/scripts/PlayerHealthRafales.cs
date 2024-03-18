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
    GameObject mainChar;
    public HealthBar healthbar;

    // Start is called before the first frame update

   
    void Start()
    {
        
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        knocback  = GetComponent<KnockBackMainRafales>();
        animator = GetComponent<Animator>();
        mainChar = GameObject.Find("mainCharacter");
        
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
            isDead = true;
            animator.SetBool("Die", true);
            gameObject.SetActive(false);
            //gamemanager.enabled = true;
            gamemanager.gameOver();
        }

        else 
        {
            animator.SetTrigger("Hit");
            
        }

    }

  
   public void RestoreHealth(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);

        // UPDATES NOW YESYES

        healthBar.SetHealth(currentHealth);
    }
 
    
}
