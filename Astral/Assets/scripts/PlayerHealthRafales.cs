using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthRafales : MonoBehaviour
{

    public int maxHealth = 250;
    public int currentHealth;
    public HealthBar healthBar;
    public bool alive;
    Animator animator;
    private KnockBackMainRafales knocback;
    private bool isDead;
    GameObject mainChar;
    public HealthBar healthbar;
    public GameOverManager gamemanager;

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
                if (Input.GetKeyDown(KeyCode.Space))
        {
            SaveHealth();
        }

    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {

      
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);


        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            animator.SetBool("Die", true);
            gameObject.SetActive(false);
            //gamemanager.enabled = true;
            gamemanager.Gameover();
            Debug.Log("Dead");
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
    public void SaveHealth()
    {
        PlayerPrefs.SetInt("PlayerHealth", currentHealth);
        PlayerPrefs.Save();
        Debug.Log("Health Saved: " + currentHealth);
    }

    // Load health from PlayerPrefs
    public void LoadHealth()
    {
        if (PlayerPrefs.HasKey("PlayerHealth"))
        {
            currentHealth = PlayerPrefs.GetInt("PlayerHealth");
            healthBar.SetHealth(currentHealth);
            Debug.Log("Health Loaded: " + currentHealth);
        }
    }
 
    
}
