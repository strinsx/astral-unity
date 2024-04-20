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
        errorSoundClip = GetComponent<AudioClip>();
        audioSource = GetComponent<AudioSource>();
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
        if (keyText.text == "Wait.")
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
        button1Attack.text = PlayerPrefs.GetString("Attack1", "F");
        firstskill.text = PlayerPrefs.GetString("Firstskill", "W");
        secondskill.text = PlayerPrefs.GetString("Secondskill", "E");
        thirdskill.text = PlayerPrefs.GetString("ThirdSkill", "R");
        dashKeyText.text = PlayerPrefs.GetString("DashKey", "Q");
    }
    public void Resetkeydefault()
    {
        PlayerPrefs.SetString("Attack1", "F");
        PlayerPrefs.SetString("Firstskill", "W");
        PlayerPrefs.SetString("Secondskill", "E");
        PlayerPrefs.SetString("ThirdSkill", "R");
        PlayerPrefs.SetString("DashSkill", "Q");

        button1Attack.text = "F";
        firstskill.text = "W";
        secondskill.text = "E";
        thirdskill.text = "R";
        dashKeyText.text = "Q";
        PlayerPrefs.Save();
    }
    public void SaveAllKeyBindingsRestartorquit()
    {
        SaveKeyBinding("Attack1", button1Attack.text);
        SaveKeyBinding("Firstskill", firstskill.text);
        SaveKeyBinding("Secondskill", secondskill.text);
        SaveKeyBinding("ThirdSkill", thirdskill.text);
        SaveKeyBinding("DashKey", dashKeyText.text);
    }
    public void Attackkey1()
    {
        button1Attack.text = "Wait.";
    }
    public void First()
    {
        firstskill.text = "Wait.";
    }
    public void Second()
    {
        secondskill.text = "Wait.";
    }
    public void Third()
    {
        thirdskill.text = "Wait.";
    }
    public void dash()
    {
        dashKeyText.text = "Wait.";
    }
}
