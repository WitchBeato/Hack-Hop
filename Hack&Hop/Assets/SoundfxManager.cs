using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundfxManager : MonoBehaviour
{
    public static float volume = 100f;
    public static SoundfxManager instance;
    [SerializeField] private AudioSource soundFXObject;
    private void Awake()
    {
        if(instance == null){
            instance = this;
        }
    }
    public void PlaySoundFX(AudioClip audioClip, Transform spawnTransform){
               //spawn in gameObject
AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

//assign the audioClip
audioSource.clip = audioClip;

//assign volume
audioSource.volume = volume;

//play sound
audioSource.Play();

//get length of sound FX clip
float clipLength = audioSource.clip.length;
Destroy(audioSource.gameObject,clipLength);        
    }
        public void PlaySoundFX(AudioClip audioClip, Transform spawnTransform,float volume){
               //spawn in gameObject
AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

//assign the audioClip
audioSource.clip = audioClip;

//assign volume
audioSource.volume = volume;

//play sound
audioSource.Play();

//get length of sound FX clip
float clipLength = audioSource.clip.length;
Destroy(audioSource.gameObject,clipLength);        
    }
}
