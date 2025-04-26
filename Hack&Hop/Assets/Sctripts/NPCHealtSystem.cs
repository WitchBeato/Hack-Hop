using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHealtSystem : MonoBehaviour, INPCHealt
{
    public float maxHP;
    public float CurrentHP;
    public bool IsDeath{
    get 
    {return isDeath;}
    set {
        isDeath = value;
    }}
    private bool isDeath = false;
    public virtual void getAttack(float value)
    {
        CurrentHP -= value;
        if(CurrentHP <= 0) setHP(0);
        isDeath = true;
    }

    public virtual void  setHP(float value)
    {
        CurrentHP = value;
    }

    public virtual void setMaxHP(float value)
    {
        maxHP = value;
    }
}
