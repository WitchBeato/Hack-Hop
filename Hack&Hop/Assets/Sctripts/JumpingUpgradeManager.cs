using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingUpgradeManager : MonoBehaviour,IUseItem
{

    private UnityEventList unityEventList;
    private MCAnimationManager mcAnimationManager;
    public float jumpForce = 1f;
    [SerializeField] private  GameObject buharLocation;
    [SerializeField] private  GameObject buhar;
    private Boolean isFirstTime = true;
    void Start()
    {
        unityEventList = FindObjectOfType<UnityEventList>();
        mcAnimationManager = FindObjectOfType<MCAnimationManager>();
        unityEventList.playerGrounded.AddListener(isGrounded);
    }
    private void isGrounded(){
        isFirstTime = true;
        mcAnimationManager.stopWrenchJump();
    }
    public void use()
    {
        GameObject player = GameObject.Find("MC");
        if(player.TryGetComponent<MovementScript>(out MovementScript body2d) && isFirstTime){
            body2d.JumpAction(jumpForce);
            isFirstTime = false;
            mcAnimationManager.playWrenchJump();
            createBuhar();
        }
    }
    private void createBuhar(){
        Instantiate(buhar,buharLocation.transform.position,Quaternion.identity);
    }
}
