using System.Collections;
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
    public float KBForce = 5;
    public int regularAttackDamage = 10; 
    public int skillDamage = 20;
    public float skillKBForce = 20;
    public float cooldown;
    float lastSkillTime = -999f;
    [SerializeField] private AudioClip baselinetest;
        [SerializeField] private AudioClip baselinetest1;


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
        if (Input.GetKeyDown(KeyCode.Z) && !isAttacking)
        {
            isAttacking = true;
            charanim.SetTrigger("Attack");
        }
        else if (Input.GetKeyDown(KeyCode.W) && !isAttacking && Time.time - lastSkillTime >= cooldown)
        {
            isAttacking = false;
            charanim.SetTrigger("Skills");
     SoundEffectManager.instance.SkillCLip(baselinetest1 , transform , 1f);
     lastSkillTime = Time.time;
        }

    }

    public void OnRegularAttack()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackpoint.transform.position, radius, enemies);

        foreach (Collider2D enemyCollider in enemy)
        {
            Debug.Log("HIT ENEMY");
            Rigidbody2D enemyRigidbody = enemyCollider.gameObject.GetComponent<Rigidbody2D>();
            if (enemyRigidbody != null)
            {
                Vector2 knockbackDirection = (enemyRigidbody.position - GetComponent<Rigidbody2D>().position).normalized;
                enemyRigidbody.AddForce(knockbackDirection * KBForce, ForceMode2D.Impulse);
            }

            enemyCollider.GetComponent<MinionHealth>().health -= regularAttackDamage;
        }
    }

    public void OnSkillAttack()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackpoint.transform.position, radius, enemies);

        foreach (Collider2D enemyCollider in enemy)
        {
            Debug.Log("HIT ENEMY WITH SKILL");

            Rigidbody2D enemyRigidbody = enemyCollider.gameObject.GetComponent<Rigidbody2D>();
            if (enemyRigidbody != null)
            {
               SoundEffectManager.instance.SkillCLip(baselinetest , transform , 1f);
                Vector2 knockbackDirection = (enemyRigidbody.position - GetComponent<Rigidbody2D>().position).normalized;
                enemyRigidbody.AddForce(knockbackDirection * skillKBForce, ForceMode2D.Impulse);
            }

            enemyCollider.GetComponent<MinionHealth>().health -= skillDamage; 
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackpoint.transform.position, radius);
    }
}
