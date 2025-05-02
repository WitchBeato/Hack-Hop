using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    public AudioClip throwphone;
    public AudioClip jump;
    public AudioClip death;
    public void playSound(AudioClip sound){
        AudioSource.PlayClipAtPoint(sound,transform.position);
    }
    public void playThrow(){
        playSound(throwphone);
    }
    public void playJump(){
        playSound(throwphone);
    }
    public void playDeath(){
        playSound(throwphone);
    }
}
