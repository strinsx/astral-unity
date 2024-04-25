using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameOverManager : MonoBehaviour
{
    public GameObject UIGameOver;
    public GameObject PauseSymbol;
    public GameObject Energybar;
    public GameObject Healthbar;
    public GameObject Abilities;
    public GameObject Bosshealth;

    public EscapePanelStages Escapedisabled;
    private bool ifgameover = false;
    // Start is called before the first frame update
    void Start()
    {
        Escapedisabled = GetComponent<EscapePanelStages>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Gameover()
    {
        PauseSymbol.SetActive(false);
        UIGameOver.SetActive(true);
        Healthbar.SetActive(false);
        Energybar.SetActive(false);
        Abilities.SetActive(false);
        Bosshealth.SetActive(false);

    }
    public bool gameovers()
    {
        return ifgameover;
    }
}
