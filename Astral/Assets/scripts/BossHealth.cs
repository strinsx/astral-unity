
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BossHealth : MonoBehaviour
{

    [SerializeField] private ParticleSystem damageparticles;
    public int health;
    public int currenthealth;
    private Animator anim;
    private bool attacked;
    private float despawnae = 2f;
    private ParticleSystem damageparticleInstance;
    private CinemachineImpulseSource impulseSource;
    public DamageFlash1 _damageFlash;
    private Vector2 attackDirection;
    private bool isAlive;
    public bool isInvurnerable = false;
    public BossHealthBar healthBar;
    public GameObject bosshealthbar;
    public AudioSource BackgroundRemove;

    [Header("Boss SFX")]
    [SerializeField] private AudioClip hurtSFX;
    [SerializeField] private AudioClip deathSFX;

     public AudioSource Victory;
    [Header("TransparentImageWhenSkillUIAppear")]
    public GameObject Energybar;
    public GameObject Abilities;
    [Header("---Portal---")]
    public GameObject portal;

    private void Start()
    {
        portal.SetActive(false);
        anim = GetComponent<Animator>();
        currenthealth = health;
        healthBar.SetMaxHealth(health);
        _damageFlash = GetComponent<DamageFlash1>();
        impulseSource = GetComponent<CinemachineImpulseSource>(); // Corrected the spelling
        Vector2 attackDirection = (this.gameObject.transform.position - transform.position).normalized;
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
            SoundEffectManager.instance.SkillCLip(hurtSFX, transform, 1f);
        

        }

        if (health <= 400)
        {
            GetComponent<Animator>().SetBool("isEnraged", true);
        }

        if (health <= 0)
        {
            anim.SetBool("isDead", true);
            Debug.Log("EnemyDead");
            isAlive = false;
            StartCoroutine(DestroyGameob());
            SoundEffectManager.instance.SkillCLip(deathSFX, transform , 1f);

        }
       

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
