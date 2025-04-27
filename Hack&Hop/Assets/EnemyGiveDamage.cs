using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGiveDamage : MonoBehaviour
{
    public float forceX = 5f, forceY = 5f;
    public float comingDamage = 10f;
    public float throwingDamage = 5f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D body2D = collision.gameObject.GetComponent<Rigidbody2D>();
        if (collision.gameObject.TryGetComponent<PlayerHealtManager>(out PlayerHealtManager healthManager))
        {
            healthManager.getAttack(comingDamage);

            // Calculate the direction from the enemy to the player


            // Apply force in the opposite direction

            //body2D.AddForce(new Vector2(0,forceY), ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
               Rigidbody2D body2D = collision.gameObject.GetComponent<Rigidbody2D>();
        if (collision.gameObject.TryGetComponent<PlayerHealtManager>(out PlayerHealtManager healthManager))
        {
            healthManager.getAttack(comingDamage);

            // Calculate the direction from the enemy to the player


            // Apply force in the opposite direction

            body2D.AddForce(new Vector2(-forceX,forceY), ForceMode2D.Impulse);
        }
    }
}