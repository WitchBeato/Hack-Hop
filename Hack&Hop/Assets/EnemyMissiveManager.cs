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
        
        // Optional: Auto-destroy after some time in case it never hits anything
        Destroy(gameObject, 5f); // Destroy after 5 seconds
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check for player health manager
        if(collision.gameObject.TryGetComponent<PlayerHealtManager>(out PlayerHealtManager manager)) {
            GetDamage(manager);

        }
        
        // Create explosion effect
        if(bombEffect != null) {
            Instantiate(bombEffect, transform.position, Quaternion.identity);
        }
                    Debug.Log("patladım");
        // Destroy the missile
        Destroy(gameObject);
    }

    public virtual void GetDamage(PlayerHealtManager playerHealtManager)
    {
        playerHealtManager.getAttack(damage);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(direction * missiveSpeed, 0f);
    }
}