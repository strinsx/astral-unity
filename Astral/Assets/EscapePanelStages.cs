using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class EscapePanelStages : MonoBehaviour
{
    private bool isPaused = false;
    private float originalTimeScale = 1f;

    public GameObject Escape;
    public GameObject Background;
    public GameObject MenuSymbol;
    public GameObject HealthBar;
    public GameObject Energybar;
    public GameObject Abilities;
    public GameObject Character;
    public GameOverManager gameover;
    public GameObject settingsPanel;
    public GameObject keybindPanel;
    public GameObject informationPanel;
    public GameObject yorno;
    public GameObject skillselection;

    void Start()
    {
        Escape.SetActive(false);
        originalTimeScale = Time.timeScale;

    }

    void Update()
    {
        if (!gameover.gameovers())
        {
            if (!IsAnyUIPanelActive())
            {
                if (Gamepad.current != null && Gamepad.current.startButton.wasPressedThisFrame)
                {
                    TogglePausemenu();
                }

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    TogglePausemenu();
                }
            }
        }
    }

    bool IsAnyUIPanelActive()
    {
        return settingsPanel != null && settingsPanel.activeSelf ||
               keybindPanel != null && keybindPanel.activeSelf ||
               informationPanel != null && informationPanel.activeSelf ||
               yorno != null && yorno.activeSelf ||
               skillselection != null && skillselection.activeSelf;
    }

    void TogglePausemenu()
    {
        if (!isPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    void PauseGame()
    {

        Character.SetActive(false);
        Abilities.SetActive(false);
        HealthBar.SetActive(false);
        Energybar.SetActive(false);
        Background.SetActive(true);
        Escape.SetActive(true);
        MenuSymbol.SetActive(false);
        isPaused = true;
        Time.timeScale = 0f;
    }

    void ResumeGame()
    {

        Character.SetActive(true);
        Abilities.SetActive(true);
        HealthBar.SetActive(true);
        Energybar.SetActive(true);
        Background.SetActive(false);
        Escape.SetActive(false);
        MenuSymbol.SetActive(true);
        isPaused = false;
        Time.timeScale = originalTimeScale;
    }
}
