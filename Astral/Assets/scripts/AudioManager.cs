using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicsource;
    public AudioClip background;
    public static AudioManager instance;
    private void Awake(){
        if (instance == null){  
            instance = this;
        DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
        
    }
    public void Start()
    {
        musicsource.clip = background;
        musicsource.Play();
}
}
