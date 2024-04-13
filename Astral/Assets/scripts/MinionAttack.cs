using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;


public class MinionAttack : MonoBehaviour
{
    public int damage;
    Animator anim;
    PlayerHealthRafales playerhealth;
    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;
    public int attackDamage = 20;
    private CinemachineImpulseSource impulseSource;
    public float shakeAmplitude = 1f;
    public float shakeFrequency = 1f; 

     [SerializeField] private AudioClip attackSFX;





    private void Start()
    {
        anim = GetComponent<Animator>();
        playerhealth = FindObjectOfType<PlayerHealthRafales>();
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

   public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.forward * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);

        if(colInfo != null)
        {
            colInfo.GetComponent<PlayerHealthRafales>();
            if(playerhealth != null)
            {
                playerhealth.TakeDamage(attackDamage);
                impulseSource.m_ImpulseDefinition.m_AmplitudeGain = shakeAmplitude;
                impulseSource.m_ImpulseDefinition.m_FrequencyGain = shakeFrequency;
                CameraShakeManager.instance.CameraShake(impulseSource);
                SoundEffectManager.instance.SkillCLip(attackSFX, transform , 1f);
            }
        }
    }

    public void SkillDamage()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.forward * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, 2, attackMask);

        if (colInfo != null)
        {
            colInfo.GetComponent<PlayerHealthRafales>();
            if (playerhealth != null)
            {
                playerhealth.TakeDamage(75);
                impulseSource.m_ImpulseDefinition.m_AmplitudeGain = shakeAmplitude;
                impulseSource.m_ImpulseDefinition.m_FrequencyGain = shakeFrequency;
                CameraShakeManager.instance.CameraShake(impulseSource);
            }
        }
    }
}
