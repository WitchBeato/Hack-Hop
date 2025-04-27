using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornDamageManager : MonoBehaviour
{
    public float damage = 20f;
    public float thornForce = 2f;
    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<PlayerHealtManager>(out PlayerHealtManager healtManager)){
        Rigidbody2D rigidbody2D = collision.gameObject.GetComponent<Rigidbody2D>();
        float recentHP = healtManager.CurrentHP;
        healtManager.getAttack(20f);
        float currentHP = healtManager.CurrentHP;
        if(currentHP != recentHP) rigidbody2D.AddForce(Vector2.up * thornForce,ForceMode2D.Impulse);
        }
        
    }

}
