using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackManager : MonoBehaviour
{
    [Header("Knockback Settings")]
    public float knockbackResistance = 1f; // Higher value means less knockback (1 = normal)
    public float recoverySpeed = 3f; // How quickly enemy recovers from knockback
    public float maxKnockbackTime = 0.5f; // Maximum time enemy stays in knockback state
    public bool disableEnemyMovement = true; // Should enemy be prevented from moving during knockback
    
    [Header("Optional Effects")]
    public AudioClip hitSoundFX;
    public GameObject hitEffectPrefab;
    
    private Rigidbody2D rb;
    private float knockbackTimer = 0f;
    private bool isInKnockback = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Handle knockback recovery
        if (isInKnockback)
        {
            knockbackTimer -= Time.deltaTime;
            
            if (knockbackTimer <= 0)
            {
                isInKnockback = false;
                
                // Re-enable enemy movement if it was disabled

            }
        }
    }
    
    public void ApplyKnockback(Vector2 direction, float force)
    {
        // Calculate actual force based on resistance
        float actualForce = force / knockbackResistance;
        
        // Apply impulse force
        rb.velocity = Vector2.zero; // Clear existing velocity
        rb.AddForce(direction * actualForce, ForceMode2D.Impulse);
        
        
        // Set knockback state
        isInKnockback = true;
        knockbackTimer = maxKnockbackTime;
        
        // Play hit sound if available
        if (hitSoundFX != null && SoundfxManager.instance != null)
        {
            SoundfxManager.instance.PlaySoundFX(hitSoundFX, transform,40f);
        }
        
        // Spawn hit effect if available
        if (hitEffectPrefab != null)
        {
            Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
        }
        
        StartCoroutine(SlowDownKnockback());
    }
    
    private IEnumerator SlowDownKnockback()
    {
        // Wait a small amount of time to let full knockback happen
        yield return new WaitForSeconds(0.1f);
        
        // Gradually reduce velocity until knockback ends
        while (isInKnockback && rb.velocity.magnitude > 0.1f)
        {
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, recoverySpeed * Time.deltaTime);
            yield return null;
        }
    }
    
    // Optional: Add a simple way to check if enemy is in knockback state
    public bool IsInKnockback()
    {
        return isInKnockback;
    }
}