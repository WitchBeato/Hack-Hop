using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    public float JumpForce = 7f;
    public float moveSpeed = 5f;
    public AudioClip playerJumpFX;
    [SerializeField] private SpriteRenderer renderer;
    
    [SerializeField] private UnityEventList unityEventList;
    [SerializeField] private IsgroundChecker isgroundChecker;
    private Vector2 movementInput;
    private Boolean isScaleLocked;
    private Quaternion lockedX;
    private float lastDirection = 1f; // Store the last direction (1 for right, -1 for left)

    private Rigidbody2D body2d;
    private bool jumpQueued;

    void Start()
    {
        body2d = GetComponent<Rigidbody2D>();
        UnityEventList.instance.playerGrounded.AddListener(CharacterGrounded);
    }

    void FixedUpdate()
    {
        body2d.velocity = new Vector2(movementInput.x * moveSpeed, body2d.velocity.y);
        
        if (jumpQueued)
        {
            jumpQueued = false;
            JumpAction(1);
        }
    }

    public void MovePlayer(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            movementInput = context.ReadValue<Vector2>();
            
            // Only update direction and rotation when grounded
            if (isgroundChecker.isGround)
            {
                // Update the last direction when player intentionally moves
                if (movementInput.x > 0.001f)
                {
                    lastDirection = 1f;
                    UpdateCharacterRotation(lastDirection);
                }
                else if (movementInput.x < -0.001f)
                {
                    lastDirection = -1f;
                    UpdateCharacterRotation(lastDirection);
                }
            }
            else
            {
                // Still update movement input for air control, but don't change rotation
                if (movementInput.x > 0.001f)
                {
                    lastDirection = 1f;
                }
                else if (movementInput.x < -0.001f)
                {
                    lastDirection = -1f;
                }
            }
        }
        else if (context.canceled)
        {
            movementInput = new Vector2(0, body2d.velocity.y);
            // Don't change direction when stopping
        }
    }
    
    private void UpdateCharacterRotation(float direction)
    {
        if (direction < 0) // Left
        {
            transform.localRotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        else // Right
        {
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }
    
    public void CharacterGrounded()
    {
        // Use the last known direction instead of velocity when landing
        UpdateCharacterRotation(lastDirection);
    }

    public void JumpPlayer(InputAction.CallbackContext context)
    {
        if (context.performed && isgroundChecker.isGround)
        {
            jumpQueued = true;
        }
    }
    
    public void playerAttack(InputAction.CallbackContext context)
    {
        if (context.performed && TryGetComponent<PlayerAttack>(out PlayerAttack playerAttack)) // opsiyonel: yere yakınsa
        {
            playerAttack.Attack();
        }
    }
    
    public void JumpAction(float multiplier)
    {
        body2d.velocity = new Vector2(body2d.velocity.x, JumpForce * multiplier);
        SoundfxManager.instance.PlaySoundFX(playerJumpFX, transform);
    }
}