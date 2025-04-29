using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IsgroundChecker : MonoBehaviour
{
public UnityEventList unityEventList;
    public float controlDistance = 0.5f;
    public bool isGround;
    public LayerMask groundLyer;
    private bool isFirstTime;

    public void FixedUpdate()
    {
        if(Physics2D.Raycast(transform.position,Vector2.down,controlDistance,groundLyer)){
            if(isFirstTime){
                unityEventList.playerGrounded.Invoke();
                isFirstTime = false;
            }

            isGround = true;
        }
        else{
            isFirstTime = true;
            isGround = false;
        }

    }
}
