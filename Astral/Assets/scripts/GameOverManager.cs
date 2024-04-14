using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameOverManager : MonoBehaviour
{
    public GameObject UIGameOver;
    public GameObject PauseSymbol;
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

        ifgameover = true;

    }
    public bool gameovers()
    {
        return ifgameover;
    }
}
