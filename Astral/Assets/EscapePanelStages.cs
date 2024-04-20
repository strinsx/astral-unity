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
    public AudioSource Backgroundsound, SoundEffect;
    public GameOverManager gameover;
    // Start is called before the first frame update
    void Start()
    {
        Escape.SetActive(false);
        originalTimeScale = Time.timeScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameover.gameovers() && Input.GetKeyDown(KeyCode.Escape))
        {
                if (!isPaused)
                {
                    SoundEffect.Pause();
                    Backgroundsound.Pause();
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
                else 
                {
                    SoundEffect.UnPause();
                    Backgroundsound.UnPause();
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
        }
    }
