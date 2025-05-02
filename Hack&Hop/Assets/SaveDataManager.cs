using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SaveDataManager : MonoBehaviour
{
    private String sceneName;
    void Awake()
    {
        if(gameObject.scene.buildIndex == -1) Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }

    public GameObject player;
    private PlayerData saveplayer;
    private Vector3 saveposition;
    public CinemachineVirtualCamera cinemachineVirtualCamera;
    public void YARRRAAA(){
        player.GetComponent<PlayerItemManager>().Save(); 
        saveplayer = player.GetComponent<PlayerData>(); 
        saveposition = player.transform.position;
        sceneName = SceneManager.GetActiveScene().name;
        Debug.Log(player.transform.position);
    }
public void loadmebro(){

    player = GameObject.Find("MC");
    PlayerHealtManager healtManager = player.GetComponent<PlayerHealtManager>();
    healtManager.setHP(healtManager.maxHP);
    healtManager.IsDeath = true;

    player.GetComponent<PlayerItemManager>().load(saveplayer);
    player.transform.position = saveposition;
}
    public void reloadScene(){
        loadmebro();
    }
    
}
