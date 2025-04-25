using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IsgroundChecker : MonoBehaviour
{
public UnityEventList unityEventList;
public Boolean isGround {private set; get;}
void OnCollisionEnter2D(Collision2D collision)
{
     isGround = true;
     unityEventList.playerGrounded.Invoke();
}
void OnCollisionExit2D(){
    isGround = false;
}
}
