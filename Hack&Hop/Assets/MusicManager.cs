using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip battleTheme; 
    public AudioClip Finalbattletheme; 
    public static MusicManager instance;
    public AudioSource audioSource;

    void Awake()
    {
        // Singleton pattern implementation
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Optional: Keep music playing between scenes
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates
            return;
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayBattle()
    {
        PlaySound(battleTheme);
    }

    public void PlayFinal()
    {
        Debug.Log("final battle çal!");
        PlaySound(Finalbattletheme);
    }

    public void PlaySound(AudioClip clip)
    {
        if (clip == null || audioSource == null) return;
        
        audioSource.clip = clip;
        audioSource.Play();
    }
}