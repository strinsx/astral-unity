using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    void Start()
    {
        int savedHealth = PlayerPrefs.GetInt("ddada", -1); // Use -1 as a flag to indicate no saved value
        if (savedHealth != -1)
        {
            SetHealth(savedHealth);
        }
        else
        {
            SetHealth((int)slider.maxValue); // Set to max value if no saved value found
        }
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
