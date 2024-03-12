using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "FIRSTMAP")
        {
            StopAudio();
            Destroy(gameObject);
        }
    }

    public void StopAudio()
    {
        musicsource.Stop();
    }

}
