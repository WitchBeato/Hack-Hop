using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimationManager : MonoBehaviour
{
    public static BossAnimationManager instance;
    private Animator animator;

    internal void playDeathAnim()
    {
        animator.SetTrigger("BossDeath");
    }
    internal AnimatorClipInfo[] giveLenght()
    {
       return animator.GetCurrentAnimatorClipInfo(0);
    }


    void Awake()
    {
        animator = GetComponent<Animator>();
        if(instance==null){
            instance =this;
            Debug.Log("this");
        }
    }
}
