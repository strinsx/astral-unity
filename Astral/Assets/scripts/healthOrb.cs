using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthOrb : MonoBehaviour
{
    public int healthRestoreAmount = 10;
    [SerializeField] private AudioClip obtainedsoundsclip;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            PlayerHealthRafales playerhealth = collision.GetComponent<PlayerHealthRafales>();
            if (playerhealth != null)
            {
                SoundEffectManager.instance.SkillCLip(obtainedsoundsclip, transform, 1f);
                playerhealth.RestoreHealth(healthRestoreAmount);
            }

            Destroy(gameObject);
        }

    }
}
