using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossMusicChanger : MonoBehaviour
{
    void Start()
    {
        UnityEventList.instance.playerDeath.AddListener(MusicManager.instance.PlayBattle);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player"){
            MusicManager.instance.PlayFinal();
        }
    }
}
