using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider energySlider;
    public float maxEnergy = 100f;
    public float energyRegenRate;
    private float currentEnergy;

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
        }
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