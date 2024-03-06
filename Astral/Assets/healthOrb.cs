using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthOrb : MonoBehaviour
{
    public int healthRestoreAmount = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            PlayerHealthRafales playerhealth = collision.GetComponent<PlayerHealthRafales>();
            if (playerhealth != null)
            {
                playerhealth.RestoreHealth(healthRestoreAmount);
            }

            Destroy(gameObject);
        }

    }
}
