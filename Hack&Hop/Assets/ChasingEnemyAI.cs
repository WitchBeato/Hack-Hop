using System;
using UnityEngine;

public class PlatformerEnemy : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float chaseSpeed = 3f; // Speed when chasing player (faster)
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckDistance = 0.5f;
    [SerializeField] private float wallCheckDistance = 0.5f;
    [SerializeField] private float playerDetectionRange = 5f; // How far the enemy can see
    [SerializeField] private LayerMask playerLayer; // Layer for the player
    
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public int direction = -1; // -1 for left, 1 for right
    private Transform player;
    private bool isChasing = false;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        
        // Create ground check if not assigned
        if (groundCheck == null)
        {
            GameObject checkObj = new GameObject("GroundCheck");
            checkObj.transform.parent = transform;
            // Position it at the front based on initial direction (left)
            checkObj.transform.localPosition = new Vector3(direction * 0.5f, -0.5f, 0);
            groundCheck = checkObj.transform;
            Debug.Log("Created groundCheck automatically. You can adjust its position in the editor.");
        }
        
        // Make sure sprite is flipped correctly at the start
        spriteRenderer.flipX = (direction < 0);
    }
    void Update()
    {
        animator.SetFloat("Speed",Math.Abs(rb.velocity.x));
    }

    private void FixedUpdate()
    {
        // Try to detect player first
        CheckForPlayer();
        
        if (isChasing && player != null)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }
    
    private void CheckForPlayer()
    {
        if (player == null) return;
        
        // Check distance to player
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        
        if (distanceToPlayer <= playerDetectionRange)
        {
            // Check if there's a clear line of sight to the player
            RaycastHit2D hit = Physics2D.Linecast(
                transform.position,
                player.position,
                groundLayer // This will check if walls block the view
            );
            
            // If nothing blocks the view (or if the player was hit), start chasing
            if (hit.collider == null || hit.collider.CompareTag("Player"))
            {
                isChasing = true;
            }
        }
        else
        {
            // Player out of range, stop chasing
            isChasing = false;
        }
    }
    
    private void ChasePlayer()
    {
        isChasingDirection();
        // Determine direction to player
        int directionToPlayer = (player.position.x > transform.position.x) ? 1 : -1;
        
        // Check if there's ground ahead before moving
        bool groundAhead = Physics2D.Raycast(
            groundCheck.position,
            Vector2.down,
            groundCheckDistance,
            groundLayer
        );
        
        // If no ground ahead, stop chasing and return to patrol
        if (!groundAhead)
        {
            isChasing = false;
            return;
        }
        
        // Set direction toward player
        if (direction != directionToPlayer)
        {
            direction = directionToPlayer;
            
            // Adjust the ground check position
            Vector3 checkPos = groundCheck.localPosition;
            checkPos.x = Mathf.Abs(checkPos.x) * direction;
            groundCheck.localPosition = checkPos;
            
            // Flip the sprite
            spriteRenderer.flipX = (direction < 0);
        }
        
        // Move toward player
        rb.velocity = new Vector2(direction * chaseSpeed, rb.velocity.y);
    }
    
    private void Patrol()
    {
        // Check if there's ground ahead
        bool groundAhead = Physics2D.Raycast(
            groundCheck.position,
            Vector2.down,
            groundCheckDistance,
            groundLayer
        );
        
        // If no ground ahead, change direction
        if (!groundAhead)
        {
            ChangeDirection();
        }
        
        // Check if there's a wall ahead
        bool wallAhead = Physics2D.Raycast(
            groundCheck.position,
            new Vector2(direction, 0),
            wallCheckDistance,
            groundLayer
        );
        
        // If wall ahead, change direction
        if (wallAhead)
        {
            ChangeDirection();
        }
        
        // Move in current direction
        rb.velocity = new Vector2(-direction * moveSpeed, rb.velocity.y);
    }
    
    private void ChangeDirection()
    {
        if(isChasing) return;
        // Change direction
        direction *= -1;
        
        // Adjust the ground check position when flipping direction
        Vector3 checkPos = groundCheck.localPosition;
        checkPos.x = Mathf.Abs(checkPos.x) * direction;
        groundCheck.localPosition = checkPos;
        
        // Flip the sprite
        spriteRenderer.flipX = (direction < 0);
    }
    private void isChasingDirection(){
        Vector3 checkPos = groundCheck.localPosition;
        checkPos.x = Mathf.Abs(checkPos.x) * direction;
        groundCheck.localPosition = checkPos;
        spriteRenderer.flipX = (direction < 0);
    }
    
    private void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;
        
        // Draw the ground check ray
        Gizmos.color = Color.green;
        Gizmos.DrawRay(groundCheck.position, Vector2.down * groundCheckDistance);
        
        // Draw the wall check ray
        Gizmos.color = Color.red;
        Gizmos.DrawRay(groundCheck.position, new Vector2(direction, 0) * wallCheckDistance);
        
        // Draw player detection range
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, playerDetectionRange);
    }
}