using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalKapıManager : MonoBehaviour
{
    public String sceneName;
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.tag == "Player"){
            SceneManager.LoadScene(sceneName);
                    Debug.Log("biri girdi");
        }
    }
}
