using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicsource;
    public AudioClip background;
    public static AudioManager instance;
    private bool audioStopped = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        musicsource.clip = background;
        musicsource.Play();
    }
    public void StopAudio()
    {
        musicsource.Stop();
        audioStopped = true;
    }

    public void DestroyAudioManager()
    {
        if (!audioStopped)
        {
            StopAudio();
        }
        Destroy(gameObject);
    }
}