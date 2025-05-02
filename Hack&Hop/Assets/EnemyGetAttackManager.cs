using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGetAttackManager : MonoBehaviour
{
    public NPCHealtSystem healtSystem;
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<PlayerThrowManager>(out PlayerThrowManager component)){
            Debug.Log(component.getDamage());
            healtSystem.getAttack(component.getDamage());
        }
    }
}
