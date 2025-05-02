using Unity.VisualScripting;
using UnityEngine;

public class EnemyMissiveManager : MonoBehaviour
{
    public int damage = 20;
    public float missiveSpeed = 2f;
    public int direction = 1; // right = 1, left = -1
    public GameObject bombEffect;
    private Rigidbody2D rb;

    void Start()
    {
        // Flip sprite based on direction
        if(direction == 1) {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        
        rb = GetComponent<Rigidbody2D>();
        
        Destroy(gameObject, 5f); // Destroy after 5 seconds
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check for player health manager
        if(collision.gameObject.TryGetComponent<PlayerHealtManager>(out PlayerHealtManager manager)) {
            GetDamage(manager);
            Destroy(gameObject);

        }
        
        // Create explosion effect
        if(bombEffect != null) {
            Instantiate(bombEffect, transform.position, Quaternion.identity);
        }
        // Destroy the missile
        DestroyMe(collision.transform);

    }

    public virtual void GetDamage(PlayerHealtManager playerHealtManager)
    {
        playerHealtManager.getAttack(damage);
    }
    public virtual void DestroyMe(Transform collisiontransform){
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(direction * missiveSpeed, 0f);
    }
}