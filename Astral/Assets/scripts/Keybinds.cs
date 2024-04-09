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


    private void Start()
    {
    }

    private void Update()
    {
        if (button1Attack.text == "|")
        {
            foreach (KeyCode keycode in Enum.GetValues(typeof(KeyCode)))
            {
                if ((keycode >= KeyCode.Alpha0 && keycode <= KeyCode.Alpha9) ||
                    (keycode >= KeyCode.A && keycode <= KeyCode.Z))
                {
                    if (Input.GetKey(keycode))
                    {
                        if (keycode >= KeyCode.Alpha0 && keycode <= KeyCode.Alpha9)
                        {
                            if (keycode == KeyCode.Alpha0)
                                button1Attack.text = "0";
                            else if (keycode == KeyCode.Alpha9)
                                button1Attack.text = "9";
                            else
                                button1Attack.text = (keycode - KeyCode.Alpha0).ToString();
                        }
                        else if (keycode >= KeyCode.A && keycode <= KeyCode.Z)
                        {
                            button1Attack.text = keycode.ToString();
                        }

                        PlayerPrefs.SetString("Attack1", button1Attack.text);
                        PlayerPrefs.Save();
                        break;
                    }
                }
            }
        }

        if (firstskill.text == "|")
        {
            foreach (KeyCode keycode in Enum.GetValues(typeof(KeyCode)))
            {
                if ((keycode >= KeyCode.Alpha0 && keycode <= KeyCode.Alpha9) ||
                    (keycode >= KeyCode.A && keycode <= KeyCode.Z))
                {
                    if (Input.GetKey(keycode))
                    {
                        if (keycode >= KeyCode.Alpha0 && keycode <= KeyCode.Alpha9)
                        {
                            if (keycode == KeyCode.Alpha0)
                                firstskill.text = "0";
                            else if (keycode == KeyCode.Alpha9)
                                firstskill.text = "9";
                            else
                                firstskill.text = (keycode - KeyCode.Alpha0).ToString();
                        }
                        else if (keycode >= KeyCode.A && keycode <= KeyCode.Z)
                        {
                            firstskill.text = keycode.ToString();
                        }

                        PlayerPrefs.SetString("Firstskill", firstskill.text);
                        PlayerPrefs.Save();
                        break;
                    }
                }
            }
        }
        if (secondskill.text == "|")
        {
            foreach (KeyCode keycode in Enum.GetValues(typeof(KeyCode)))
            {
                if ((keycode >= KeyCode.Alpha0 && keycode <= KeyCode.Alpha9) ||
                    (keycode >= KeyCode.A && keycode <= KeyCode.Z))
                {
                    if (Input.GetKey(keycode))
                    {
                        if (keycode >= KeyCode.Alpha0 && keycode <= KeyCode.Alpha9)
                        {
                            if (keycode == KeyCode.Alpha0)
                                secondskill.text = "0";
                            else if (keycode == KeyCode.Alpha9)
                                secondskill.text = "9";
                            else
                                secondskill.text = (keycode - KeyCode.Alpha0).ToString();
                        }
                        else if (keycode >= KeyCode.A && keycode <= KeyCode.Z)
                        {
                            secondskill.text = keycode.ToString();
                        }

                        PlayerPrefs.SetString("Secondskill", secondskill.text);
                        PlayerPrefs.Save();
                        break;
                    }
                }
            }
        }
        if (thirdskill.text == "|")
        {
            foreach (KeyCode keycode in Enum.GetValues(typeof(KeyCode)))
            {
                if ((keycode >= KeyCode.Alpha0 && keycode <= KeyCode.Alpha9) ||
                    (keycode >= KeyCode.A && keycode <= KeyCode.Z))
                {
                    if (Input.GetKey(keycode))
                    {
                        if (keycode >= KeyCode.Alpha0 && keycode <= KeyCode.Alpha9)
                        {
                            if (keycode == KeyCode.Alpha0)
                                thirdskill.text = "0";
                            else if (keycode == KeyCode.Alpha9)
                                thirdskill.text = "9";
                            else
                                thirdskill.text = (keycode - KeyCode.Alpha0).ToString();
                        }
                        else if (keycode >= KeyCode.A && keycode <= KeyCode.Z)
                        {
                            thirdskill.text = keycode.ToString();
                        }

                        PlayerPrefs.SetString("ThirdSkill", thirdskill.text);
                        PlayerPrefs.Save();
                        break;
                    }
                }
            }
        }
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
}
