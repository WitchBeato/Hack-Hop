using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    public float JumpForce = 7f;
    public float moveSpeed = 5f;
    [SerializeField] private SpriteRenderer renderer;
    private Vector2 movementInput;
    [SerializeField] private IsgroundChecker isgroundChecker;
    private Rigidbody2D body2d;
    private bool isJumping = false;

    void Start()
    {
        body2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        body2d.velocity = new Vector2(movementInput.x * moveSpeed, body2d.velocity.y);
    }

    public void MovePlayer(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            movementInput = context.ReadValue<Vector2>();
            if(movementInput.x < 0) transform.localScale = new Vector3(-1,1);
            else if(movementInput.x > 0) transform.localScale = new Vector3(1,1);
        }
        else if (context.canceled)
        {
            movementInput = Vector2.zero;
        }
    }

    public void JumpPlayer(InputAction.CallbackContext context)
    {
        if (context.performed && isgroundChecker.isGround) // opsiyonel: yere yakınsa
        {
            body2d.velocity = new Vector2(body2d.velocity.x, JumpForce);
            isJumping = true;
        }
    }
     public void playerAttack(InputAction.CallbackContext context)
    {
        if (context.performed && TryGetComponent<PlayerAttack>(out PlayerAttack playerAttack)) // opsiyonel: yere yakınsa
        {
            playerAttack.Attack();
        }
    }
}
