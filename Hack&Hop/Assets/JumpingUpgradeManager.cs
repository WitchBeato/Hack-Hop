using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingUpgradeManager : MonoBehaviour,IUseItem
{

    private UnityEventList unityEventList;
    private Boolean isFirstTime = true;
    void Start()
    {
        unityEventList = FindObjectOfType<UnityEventList>();
        unityEventList.playerGrounded.AddListener(isGrounded);
    }
    private void isGrounded(){
        isFirstTime = true;
    }
    public void use()
    {
        GameObject player = GameObject.FindWithTag ("Player");
        Debug.Log(player.name);
        if(player.TryGetComponent<MovementScript>(out MovementScript body2d) && isFirstTime){
            body2d.JumpAction(1f);
            isFirstTime = false;
        }
    }
}
