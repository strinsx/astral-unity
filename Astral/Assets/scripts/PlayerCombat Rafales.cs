using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCombat : MonoBehaviour
{
    public Animator charanim;
    public bool isAttacking = false;
    public static PlayerCombat instance;
    public GameObject attackpoint;
    public float radius;
    public LayerMask enemies;
    public float KBForce = 2;
    public int regulardashDamage = 1;
    public int regularAttackDamage = 10;
    public int skillDamage = 20;
    public float skillKBForce = 20;
    public float skill1Cooldown = 2f;
    public float skill2Cooldown = 4f;
    float lastSkillTime = -999f;
    float lastSkillTime2 = -999f;
    public bool skill1Enabled;
    public bool skill2Enabled;
    public bool skill3Enabled;
    public float skillActivationDelay = 0.5f;
    [SerializeField] private AudioClip baselinetest;
    [SerializeField] private AudioClip baselinetest1;
    [SerializeField] private AudioClip baselinetest2;
    private bool attackkeypressed = true;
    private float attackDelay = 0.1f;
    private float currentDelayTimer = 0f;
    public EnergyBar energyBar;
    public Image abilityImage1;
    public Image abilityImage2;
    private bool isSkill1Cooldown = false;
    private bool isSkill2Cooldown = false;
    private float currentSkill1Cooldown;
    private float currentSkill2Cooldown;

    private void Awake()
    {
        instance = this;
    }
      void Start()
    {
        charanim = GetComponent<Animator>();
        LoadSkillsCooldown();
    }
    private void Update()
    {
        Attack();
        UpdateSkillCooldowns();
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !attackkeypressed && !isAttacking)
        {
            attackkeypressed = true;
            currentDelayTimer = attackDelay;
        }

        if (attackkeypressed)
        {
            currentDelayTimer -= Time.deltaTime;

            if (currentDelayTimer <= 0)
            {
                isAttacking = true;
                charanim.SetTrigger("Attack");
                attackkeypressed = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.W) && !isAttacking && Time.time - lastSkillTime >= skill1Cooldown && energyBar.CanAttack(20))
        {
            isAttacking = false;
            if (skill1Enabled)
            {
                charanim.SetTrigger("Skills");
                SoundEffectManager.instance.SkillCLip(baselinetest1, transform, 1f);
                lastSkillTime = Time.time;
                skillActivationDelay = Time.time;
                energyBar.UseEnergy(40);
                StartCooldown(ref currentSkill1Cooldown, skill1Cooldown, ref isSkill1Cooldown, abilityImage1);
            }
        }
        else if (Input.GetKeyDown(KeyCode.R) && !isAttacking && Time.time - lastSkillTime2 >= skill2Cooldown && energyBar.CanAttack(30))
        {
            isAttacking = false;
            if (skill2Enabled)
            {
                charanim.SetTrigger("Skill2");
                SoundEffectManager.instance.SkillCLip(baselinetest2, transform, 1f);
                lastSkillTime2 = Time.time;
                skillActivationDelay = Time.time;
                energyBar.UseEnergy(60);
                StartCooldown(ref currentSkill2Cooldown, skill2Cooldown, ref isSkill2Cooldown, abilityImage2);
            }
        }
    }

    void StartCooldown(ref float currentCooldown, float maxCooldown, ref bool isCooldown, Image skillImage)
    {
        isCooldown = true;
        currentCooldown = maxCooldown;
        UpdateSkillCooldownUI(skillImage, currentCooldown, maxCooldown);
        SaveSkillsCooldown();
    }

    void UpdateSkillCooldowns()
    {
        UpdateCooldown(ref currentSkill1Cooldown, skill1Cooldown, ref isSkill1Cooldown, abilityImage1);
        UpdateCooldown(ref currentSkill2Cooldown, skill2Cooldown, ref isSkill2Cooldown, abilityImage2);
    }

    void UpdateCooldown(ref float currentCooldown, float maxCooldown, ref bool isCooldown, Image skillImage)
    {
        if (isCooldown)
        {
            currentCooldown -= Time.deltaTime;
            if (currentCooldown <= 0f)
            {
                isCooldown = false;
                currentCooldown = 0f;
                skillImage.fillAmount = 0f;
            }
            else
            {
                UpdateSkillCooldownUI(skillImage, currentCooldown, maxCooldown);
            }
        }
    }
    void SaveSkillsCooldown()
    {
        // Save current cooldowns to PlayerPrefs
        PlayerPrefs.SetFloat("Skill1Cooldown", currentSkill1Cooldown);
        PlayerPrefs.SetFloat("Skill2Cooldown", currentSkill2Cooldown);
        // Add more PlayerPrefs saves for additional skills if needed
    }

    void LoadSkillsCooldown()
    {
        currentSkill1Cooldown = PlayerPrefs.GetFloat("Skill1Cooldown", skill1Cooldown);
        currentSkill2Cooldown = PlayerPrefs.GetFloat("Skill2Cooldown", skill2Cooldown);
    }

    void UpdateSkillCooldownUI(Image skillImage, float currentCooldown, float maxCooldown)
    {
        skillImage.fillAmount = currentCooldown / maxCooldown;
    }
    public void EnableSkill1()
    {
        skill1Enabled = true;
        PlayerPrefs.SetInt("Skill1Enabled", skill1Enabled ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void EnableSkill2()
    {
        skill2Enabled = true;
        PlayerPrefs.SetInt("Skill2Enabled", skill2Enabled ? 1 : 0);
        PlayerPrefs.Save();
    }
    public void EnableSkill3()
    {
        skill3Enabled = true;
        PlayerPrefs.SetInt("Skill3Enabled", skill3Enabled ? 1 : 0);
        PlayerPrefs.Save();
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

            BossHealth bossHealth = enemyCollider.gameObject.GetComponent<BossHealth>();
            AstralBossHealth astralHealth = enemyCollider.gameObject.GetComponent<AstralBossHealth>();


            if (bossHealth != null)
            {
                bossHealth.health -= regularAttackDamage;
            }
            if(astralHealth != null)
            {
                astralHealth.health -= regularAttackDamage;
            }
            else
            {
                enemyCollider.GetComponent<MinionHealth>().health -= regularAttackDamage;
            }

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

            BossHealth bossHealth = enemyCollider.gameObject.GetComponent<BossHealth>();
            AstralBossHealth astralHealth = enemyCollider.gameObject.GetComponent<AstralBossHealth>();


            if (bossHealth != null)
            {
                bossHealth.health -= 100;
            }
            if (astralHealth != null)
            {
                astralHealth.health -= 100;
            }
            else
            {
                enemyCollider.GetComponent<MinionHealth>().health -= 30;
            }
        }
    }

    public void OnSkillAttack1()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackpoint.transform.position, radius, enemies);

        foreach (Collider2D enemyCollider in enemy)
        {
            Debug.Log("HIT ENEMY WITH SKILL");

            Rigidbody2D enemyRigidbody = enemyCollider.gameObject.GetComponent<Rigidbody2D>();
            if (enemyRigidbody != null)
            {
                Vector2 knockbackDirection = (enemyRigidbody.position - GetComponent<Rigidbody2D>().position).normalized;
                enemyRigidbody.AddForce(knockbackDirection * skillKBForce, ForceMode2D.Impulse);
            }

            BossHealth bossHealth = enemyCollider.gameObject.GetComponent<BossHealth>();
            AstralBossHealth astralHealth = enemyCollider.gameObject.GetComponent<AstralBossHealth>();


            if (bossHealth != null)
            {
                bossHealth.health -= 150;
            }
            if (astralHealth != null)
            {
                astralHealth.health -= 150;

                PlayerHealthRafales playerHealth = GetComponent<PlayerHealthRafales>();
                if (playerHealth != null)
                {
                    playerHealth.RestoreHealth(25);
                }
            }
            else
            {
                MinionHealth minionHealth = enemyCollider.GetComponent<MinionHealth>();
                if(minionHealth != null)
                {
                    minionHealth.health -= 30;

                    PlayerHealthRafales playerHealth = GetComponent<PlayerHealthRafales>();
                    if (playerHealth != null)
                    {
                        playerHealth.RestoreHealth(2);
                    }

                }

            }
        }
    }



    public void OnRegularDash()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackpoint.transform.position, radius, enemies);

        foreach (Collider2D enemyCollider in enemy)
        {
            Debug.Log("HIT BY DASH");
            Rigidbody2D enemyRigidbody = enemyCollider.gameObject.GetComponent<Rigidbody2D>();
            if (enemyRigidbody != null)
            {
                Vector2 knockbackDirection = (enemyRigidbody.position - GetComponent<Rigidbody2D>().position).normalized;
                enemyRigidbody.AddForce(knockbackDirection * 10, ForceMode2D.Impulse);
            }

            BossHealth bossHealth = enemyCollider.gameObject.GetComponent<BossHealth>();
            AstralBossHealth astralHealth = enemyCollider.gameObject.GetComponent<AstralBossHealth>();


            if (bossHealth != null)
            {
                bossHealth.health -= regulardashDamage;
            }
            if (astralHealth != null)
            {
                astralHealth.health -= regulardashDamage;
            }
            else
            {
                enemyCollider.GetComponent<MinionHealth>().health -= regulardashDamage;
            }


        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackpoint.transform.position, radius);
    }
}
