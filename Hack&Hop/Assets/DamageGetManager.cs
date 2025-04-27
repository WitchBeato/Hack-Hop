using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageGetManager : MonoBehaviour
{
    [SerializeField] private float damage;
    public float Damage {
        get{
            return damage;
        } 
        set {
            damage = value;
        }
    }
    public float getDamage(){
        return Damage;
    }
}
