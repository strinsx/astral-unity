using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingOrb : MonoBehaviour
{
    public int healthRestoreAmount = 15;
    public int maxDamageAmount = 20;
    [SerializeField] private AudioClip obtainedmove;
    [SerializeField] private AudioClip damagemove;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            PlayerHealthRafales playerhealth = collision.GetComponent<PlayerHealthRafales>();
            if (playerhealth != null)
            {

                if(Random.value < 0.5f)
                {
                    int healthRestore = Random.Range(1, healthRestoreAmount + 1);
                    SoundEffectManager.instance.SkillCLip(obtainedmove, transform, 1f);
                    playerhealth.RestoreHealth(healthRestore);

                } 
                else
                {
                    int damage = Random.Range(1, maxDamageAmount + 1);
                    SoundEffectManager.instance.SkillCLip(damagemove, transform, 1f);
                    playerhealth.TakeDamage(damage);
                }
            }

            Destroy(gameObject);
        }

    }
}
