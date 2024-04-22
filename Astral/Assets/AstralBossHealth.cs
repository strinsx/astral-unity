
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class AstralBossHealth : MonoBehaviour
{

    [SerializeField] private ParticleSystem damageparticles;
    public int health;
    public int currenthealth;
    private Animator anim;
    private bool attacked;
    private float despawnae = 2f;
    public AnimationClip main_death;
    public Animation animationcomponent;
    private ParticleSystem damageparticleInstance;
    private CinemachineImpulseSource impulseSource;
    public DamageFlash1 _damageFlash;
    private Vector2 attackDirection;
    public KnockBackMainRafales knockback;
    private bool isAlive;
    public bool isInvurnerable = false;
    public BossHealthBar healthBar;
    public GameObject bosshealthbar;
    public AudioSource BackgroundRemove;
    public AudioSource Victory;
    [SerializeField] private AudioClip baselinetest2;
    [Header("---Portal---")]
    public GameObject portal;
    public int healthTrigger = 750;
    private bool hasSpawneBosses = false;

    public bool vibrationTriggered = false;


    private void Start()
    {
        portal.SetActive(false);
        anim = GetComponent<Animator>();
        currenthealth = health;
        healthBar.SetMaxHealth(health);
        _damageFlash = GetComponent<DamageFlash1>();
        impulseSource = GetComponent<CinemachineImpulseSource>(); // Corrected the spelling
        Vector2 attackDirection = (this.gameObject.transform.position - transform.position).normalized;
        knockback = GetComponent<KnockBackMainRafales>();
        isAlive = true;


    }


    private void Update()
    {
        hit();
    }

    public void hit()
    {

        if (!isAlive)
            return;



        if (health < currenthealth)
        {
            currenthealth = health;
            anim.SetTrigger("Attacked");
            healthBar.SetHealth(currenthealth);
            CameraShakeManager.instance.CameraShake(impulseSource);
            SpawnDamageParticles(attackDirection);
            _damageFlash.CallDps();
            if (!vibrationTriggered)
            {
                StartCoroutine(TriggerVibration());
            }

        }

        if (health <= healthTrigger && !hasSpawneBosses)
        {
            GetComponent<Animator>().SetBool("isEnraged", true);
            hasSpawneBosses = true;
            SoundEffectManager.instance.SkillCLip(baselinetest2, transform, 1f);

        }

        if (health <= 0)
        {
            anim.SetBool("isDead", true);
            Debug.Log("EnemyDead");
            isAlive = false;
            StartCoroutine(DestroyGameob());


        }
        if (health <= 0)
        {

        }

    }
    IEnumerator TriggerVibration()
    {
        vibrationTriggered = true;
        Gamepad.current.SetMotorSpeeds(1f, 1f);
        yield return new WaitForSeconds(1f);
        Gamepad.current.SetMotorSpeeds(0, 0);
        vibrationTriggered = false;
    }

    IEnumerator DestroyGameob()
    {
        portal.SetActive(true);
        Debug.Log("Portal");

        BackgroundRemove.volume = 0.4f;
        Victory.Play();



        yield return new WaitForSeconds(despawnae);

        Destroy(this.gameObject);
        Destroy(bosshealthbar);
    }

    private void SpawnDamageParticles(Vector2 attackDirection)
    {

        Quaternion spawnRotation = Quaternion.FromToRotation(Vector2.right, attackDirection);
        damageparticleInstance = Instantiate(damageparticles, transform.position, Quaternion.identity);

    }




}
