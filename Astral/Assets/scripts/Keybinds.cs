using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using UnityEngine;

public class Keybinds : MonoBehaviour
{

    [SerializeField] public TextMeshProUGUI button1Attack;
    [SerializeField] public TextMeshProUGUI firstskill;
    [SerializeField] public TextMeshProUGUI secondskill;
    [SerializeField] public TextMeshProUGUI thirdskill;
    [SerializeField] public TextMeshProUGUI dashKeyText;

    [SerializeField] private TextMeshProUGUI errorMessageText;
    [SerializeField] private AudioClip errorSoundClip;
    [SerializeField] private float errorMessageDisplayDuration = 2f;
    private Coroutine errorMessageCoroutine;
    private AudioSource audioSource;


    private void Start()
    {
        LoadKeyBindings();
    }

    private void Update()
    {
        UpdateKeyBinding(button1Attack, "Attack1");
        UpdateKeyBinding(firstskill, "Firstskill");
        UpdateKeyBinding(secondskill, "Secondskill");
        UpdateKeyBinding(thirdskill, "ThirdSkill");
        UpdateKeyBinding(dashKeyText, "DashKey");
    }
    void UpdateKeyBinding(TextMeshProUGUI keyText, string keyName)
    {
        if (keyText.text == "|")
        {
            foreach (KeyCode keycode in Enum.GetValues(typeof(KeyCode)))
            {
                if ((keycode >= KeyCode.Alpha0 && keycode <= KeyCode.Alpha9) ||
                    (keycode >= KeyCode.A && keycode <= KeyCode.Z))
                {
                    if (Input.GetKey(keycode))
                    {

                        bool isKeyAssigned = false;
                        string pressedKey = GetKeyTextRepresentation(keycode);

                        if (pressedKey == button1Attack.text ||
                            pressedKey == firstskill.text ||
                            pressedKey == secondskill.text ||
                            pressedKey == thirdskill.text ||
                            pressedKey == dashKeyText.text) 
                        {
                            Debug.LogWarning("This key is already assigned to another action!");
                            ShowErrorMessage("This key is already assigned, please choose another key.");
                            PlayErrorSound();
                            isKeyAssigned = true;
                        }

                        if (!isKeyAssigned)
                        {
                            keyText.text = pressedKey;

                            PlayerPrefs.SetString(keyName, pressedKey);
                            PlayerPrefs.Save();
                            SaveKeyBinding(keyName, pressedKey);
                            break;
                        }
                    }
                }
            }
        }
    }
    void ShowErrorMessage(string message)
    {
        if (errorMessageCoroutine != null)
        {
            StopCoroutine(errorMessageCoroutine);
        }
        errorMessageText.text = message;
        errorMessageCoroutine = StartCoroutine(HideErrorMessage());
    }

    IEnumerator HideErrorMessage()
    {
        yield return new WaitForSeconds(errorMessageDisplayDuration);
        errorMessageText.text = "";
    }
    void PlayErrorSound()
    { 
        if (errorSoundClip != null && audioSource != null)
        {
            audioSource.PlayOneShot(errorSoundClip);
        }
    }

    string GetKeyTextRepresentation(KeyCode keycode)
    {
        if (keycode >= KeyCode.Alpha0 && keycode <= KeyCode.Alpha9)
        {
            if (keycode == KeyCode.Alpha0)
                return "0";
            else if (keycode == KeyCode.Alpha9)
                return "9";
            else
                return (keycode - KeyCode.Alpha0).ToString();
        }
        else if (keycode >= KeyCode.A && keycode <= KeyCode.Z)
        {
            return keycode.ToString();
        }

        return "";
    }

    void SaveKeyBinding(string keyName, string keyValue)
    {
        PlayerPrefs.SetString(keyName, keyValue);
        PlayerPrefs.Save();
    }
    void LoadKeyBindings()
    {
        button1Attack.text = PlayerPrefs.GetString("Attack1", "Z");
        firstskill.text = PlayerPrefs.GetString("Firstskill", "W");
        secondskill.text = PlayerPrefs.GetString("Secondskill", "R");
        thirdskill.text = PlayerPrefs.GetString("ThirdSkill", "E");
        dashKeyText.text = PlayerPrefs.GetString("DashKey", "Q");
    }
    public void Resetkeydefault()
    {
        PlayerPrefs.SetString("Attack1", "Z");
        PlayerPrefs.SetString("Firstskill", "W");
        PlayerPrefs.SetString("Secondskill", "R");
        PlayerPrefs.SetString("ThirdSkill", "E");
        PlayerPrefs.SetString("DashSkill", "Q");

        button1Attack.text = "Z";
        firstskill.text = "W";
        secondskill.text = "R";
        thirdskill.text = "E";
        dashKeyText.text = "Q";
        PlayerPrefs.Save();
    } 
    public void Attackkey1()
    {
        button1Attack.text = "|";
    }
    public void First()
    {
        firstskill.text = "|";
    }
    public void Second()
    {
        secondskill.text = "|";
    }
    public void Third()
    {
        thirdskill.text = "|";
    }
    public void dash()
    {
        dashKeyText.text = "|";
    }
}
