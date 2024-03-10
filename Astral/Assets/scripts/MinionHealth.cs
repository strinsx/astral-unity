
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MinionHealth : MonoBehaviour
{

    [SerializeField] private ParticleSystem damageparticles;
    [SerializeField] public GameObject zxc;
    public GameObject FloatingTextPrefab;
    public float health;
    public float currenthealth;
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
    
    private void Start()
    {
        anim = GetComponent<Animator>();
        currenthealth = health;
       _damageFlash  = GetComponent<DamageFlash1>();
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
        
        if(!isAlive)
        return;
        
            if (health < currenthealth)
            {
                currenthealth = health;
                anim.SetTrigger("Attacked");
                CameraShakeManager.instance.CameraShake(impulseSource);
                SpawnDamageParticles(attackDirection);
                _damageFlash.CallDps();
            }

            if (health <= 0)
            {
                anim.SetBool("isDead", true);
                Debug.Log("EnemyDead");
                isAlive = false;
                StartCoroutine(DestroyGameob());
            }
        
    }

    IEnumerator DestroyGameob()
    {
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);

        yield return new WaitForSeconds(despawnae);

        Destroy(this.gameObject);
    }

    private void SpawnDamageParticles(Vector2 attackDirection)
    {

        Quaternion spawnRotation = Quaternion.FromToRotation(Vector2.right, attackDirection); 
        damageparticleInstance = Instantiate(damageparticles, transform.position, Quaternion.identity);

        }

 
}
