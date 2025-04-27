using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SaveDataManager : MonoBehaviour
{
        private String sceneName;
    void Awake()
    {
        if(gameObject.scene.buildIndex == -1) Destroy(gameObject);
        loadmebro();
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }

    public GameObject player;
    private PlayerData saveplayer;
    private Transform saveposition;
    public CinemachineVirtualCamera cinemachineVirtualCamera;
    public void YARRRAAA(){
        Debug.Log("save oldu");
        player.GetComponent<PlayerItemManager>().Save(); 
        saveplayer = player.GetComponent<PlayerData>(); 
        saveposition = player.transform;
        sceneName = SceneManager.GetActiveScene().name;
        Debug.Log(player.transform.position);
    }
public void loadmebro(){
    Debug.Log("load oldu");

    player = GameObject.Find("MC");

    if(saveposition == null) {
        Debug.LogWarning("No saved position found yet.");
        return;
    }

    Debug.Log("burası loadlandı");
    player.GetComponent<PlayerItemManager>().load(saveplayer);
    player.transform.position = saveposition.position;
}
    public void reloadScene(){
        SceneManager.LoadScene(sceneName);
    }
}
