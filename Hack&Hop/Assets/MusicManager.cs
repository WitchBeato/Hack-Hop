using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip battleTheme; 
    public AudioClip Finalbattletheme; 
    public void playBattle(){
        playSound(battleTheme);
    }
    public void playFinal(){
        playSound(Finalbattletheme);
    }
    public void playSound(AudioClip clip){

    }
}
