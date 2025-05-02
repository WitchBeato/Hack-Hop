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

    internal void playAttackRocket()
    {
                animator.SetTrigger("Rocket");
    }
    internal void playWhipAnimation()
    {
                animator.SetTrigger("Whip");
    }
    public void killYourself(){
        Destroy(gameObject);
    }
    
    public void waitForAnimation(){
        StartCoroutine(MyDelayedFunction(giveLenght().Length));
    }
      IEnumerator MyDelayedFunction(float time)
    {
        
        // 2 saniye bekle
        yield return new WaitForSeconds(time);
        
    }

    internal void whipAnimationEnd()
    {
        throw new NotImplementedException();
    }
}
