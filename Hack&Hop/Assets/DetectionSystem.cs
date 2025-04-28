using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float detectionRange = 5f;
    public float moveSpeed = 2f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireCooldown = 1f;

    private float fireTimer;

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= detectionRange)
        {
            // Oyuncuya doğru hareket
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

            // Oyuncuya ateş et
            fireTimer += Time.deltaTime;
            if (fireTimer >= fireCooldown)
            {
                Fire();
                fireTimer = 0f;
            }
        }
    }

    void Fire()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void OnDrawGizmosSelected()
    {
        // Görüş alanını sahnede görsel olarak çiz
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
