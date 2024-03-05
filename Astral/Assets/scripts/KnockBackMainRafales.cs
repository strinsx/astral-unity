using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackMainRafales : MonoBehaviour
{
    public float knockbacktime = 0.2f;
    public float hitDirectForce = 10f;
    public float constForce = 5f;
    public float inputForce = 7.5f;
    public float inputScale = 0.4f;



    private Coroutine knockbackCourtine;
    private Rigidbody2D rb;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public  bool GettingBack {  get; private set; }

    public IEnumerator KnockbackAction(Vector2 hitDirection, Vector2 constantForceDirection, float inputDirection)
    {
        GettingBack = true;


        Vector2 hitForce;
        Vector2 constantForce;
        Vector2 knockbackForce;
        Vector2 combinedforce;

        hitForce = hitDirection * hitDirectForce;
        constantForce = constantForceDirection * constForce;
        
        float elapsedTime = 0f;
        while (elapsedTime < knockbacktime)
        {
            elapsedTime += Time.fixedDeltaTime;

            knockbackForce = hitForce + constantForce;

            if(inputDirection != 0)
            {
                combinedforce = knockbackForce + new Vector2(inputDirection, 0f) * inputScale;

      
            }
            else
            {
                combinedforce = knockbackForce;
            }

            rb.velocity = combinedforce;

            yield return new WaitForFixedUpdate();
        }

        GettingBack = false;
    }

    public void CallKnockback(Vector2 hitDirection, Vector2 constantForceDirection, float inputDirection)
    {
        knockbackCourtine = StartCoroutine(KnockbackAction(hitDirection, constantForceDirection, inputDirection));
    }
}
