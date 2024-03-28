using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    void Start()
    {
        int savedHealth = PlayerPrefs.GetInt("HealthBarValue", (int)slider.maxValue);
        SetHealth(savedHealth);
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        PlayerPrefs.SetInt("MaxHealth", health);
        PlayerPrefs.Save();
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        PlayerPrefs.SetInt("HealthBarValue", health);
        PlayerPrefs.Save();
    }
        public void ResetHealth()
    {
        int maxHealth = PlayerPrefs.GetInt("MaxHealth", (int)slider.maxValue);
        SetHealth(maxHealth);
    }

}
