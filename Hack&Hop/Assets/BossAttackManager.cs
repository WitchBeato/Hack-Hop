using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackManager : MonoBehaviour
{
    public Transform[] missiveLocations;
    public Transform whipAttackLocation;
    public GameObject missive;
    public GameObject whipAttack;
    public static BossAttackManager instance;
    void Start()
    {
        if(instance == null){
            instance = this;
        }
    }
    public void AttackRocket(){
        BossAnimationManager.instance.playAttackRocket();
        foreach (Transform location in missiveLocations)
        {
            Instantiate(missive,location.position,Quaternion.identity);
        }
    }
    public void AttackWhip(){
        BossAnimationManager.instance.playWhipAnimation();


    }
    public  void AttackWhipContiune(){
        Instantiate(whipAttack,whipAttackLocation.position,Quaternion.identity);
    }
  
}
