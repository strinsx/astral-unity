using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameOverManager : MonoBehaviour
{
    public GameObject UIGameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Gameover(){
      UIGameOver.SetActive(true);
    }
}
