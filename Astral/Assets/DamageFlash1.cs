using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFlash1 : MonoBehaviour
{
    [SerializeField] private Color _flashColor = Color.white;
    [SerializeField] private float _flashTime = 0.25f;

    private SpriteRenderer spriteRenderer;
    private Material _material;
    private Coroutine _dpsCoroutine;
    private Color _originalcolor;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        _originalcolor = spriteRenderer.color;
        Init();
    }

    private void Init()
    {
        _material = spriteRenderer.material;


   
    }



    public void CallDps()
    {
        _dpsCoroutine = StartCoroutine(DPSFlash());
    }
    
    private IEnumerator DPSFlash()
    {
        SetColor();

        float currentFlashAmount = 0f;
        float elapsedTime = 0f;
        while (elapsedTime < _flashTime) 
        
        {
            elapsedTime += Time.deltaTime;
            currentFlashAmount = Mathf.Lerp(1f, 0f, (elapsedTime / _flashTime));
            SetFlashAmount(currentFlashAmount);

            yield return null;
        }

        SetFlashAmount(0f);
        SetColor();
    }

    private void SetColor()
    {
        _material.SetColor("_Color", _flashColor);
    }

    private void SetFlashAmount(float amount)
    {
        _material.SetFloat("_AmountFlash", amount);
    }
}
