using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider energySlider;
    public float maxEnergy = 250f;
    public float energyRegenRate;
    private float currentEnergy;
    public GameObject notEnoughEnergyIndicator;
    private Coroutine energyCoroutine;
    public Camera mainCamera;



    void Start()
    {
        currentEnergy = maxEnergy;
        energySlider.maxValue = maxEnergy;
        energySlider.value = currentEnergy;

        StartCoroutine(RegenerateEnergy());
    }



    IEnumerator RegenerateEnergy()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            currentEnergy = Mathf.Min(currentEnergy + energyRegenRate, maxEnergy);
            energySlider.value = currentEnergy;
            if (currentEnergy < 20)
            {
                notEnoughEnergyIndicator.SetActive(true);
            } else
            {
                notEnoughEnergyIndicator.SetActive(false);
            }
        }
    }
    private void OnDisable()
    {
        StopCoroutine(energyCoroutine);
        PlayerPrefs.SetFloat("SaveEnergy", currentEnergy);
    }

    private void OnEnable()
    {
        energyCoroutine = StartCoroutine(RegenerateEnergy());
    }

    public bool CanAttack(float energyCost)
    {
        return currentEnergy >= energyCost;
    }

    public void UseEnergy(float energyCost)
    {
        currentEnergy -= energyCost;
        energySlider.value = currentEnergy;
        PlayerPrefs.SetFloat("SaveEnergy", currentEnergy);
    }
}
