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

    public void FixedUpdate()
    {
        if(Physics2D.Raycast(transform.position,Vector2.down,controlDistance,groundLyer)){
            unityEventList.playerGrounded.Invoke();
            isGround = true;
        }
        else{
                isGround = false;
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
{

}
void OnCollisionExit2D(){
    isGround = false;
}
}
