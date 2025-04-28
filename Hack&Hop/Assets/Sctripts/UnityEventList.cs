using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventList : MonoBehaviour
{
    public static UnityEventList instance;
    private void Awake()
    {
        if(instance == null){
            instance = this;
        }
    }
    public UnityEvent playerGrounded;
    public UnityEvent playerAttacked;
    public UnityEvent playerGainUpgrade;
    public UnityEvent playerSaveGame;
    public UnityEvent playerDeath;
    public UnityEvent loadGame;
}
