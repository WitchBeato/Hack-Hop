using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCAnimationManager : MonoBehaviour
{
    public Rigidbody2D characterBody;
    [SerializeField]private UnityEventList unityEventList;
    public Animator animator;
    void Start()
    {
        unityEventList.playerAttacked.AddListener(AttackAnimation);
    }
    void FixedUpdate()
    {
        Vector2 bodyVelocity = characterBody.velocity;
        animator.SetFloat("Speed",Math.Abs(bodyVelocity.x));
        animator.SetFloat("JumpVelocity",bodyVelocity.y);
    }
    void AttackAnimation(){
    }

    internal void playWrenchJump()
    {
        animator.SetBool("WrenchJump",true);
    }
    internal void stopWrenchJump()
    {
        animator.SetBool("WrenchJump",false);
    }
}
