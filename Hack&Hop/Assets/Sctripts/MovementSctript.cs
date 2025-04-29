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

    private Rigidbody2D body2d;
    private bool jumpQueued;

    void Start()
    {
        body2d = GetComponent<Rigidbody2D>();
        unityEventList.playerGrounded.AddListener(unlockXScale);
    }

    void FixedUpdate()
    {
    body2d.velocity = new Vector2(movementInput.x * moveSpeed, body2d.velocity.y);
    
    if (jumpQueued)
    {
        JumpAction(1);
        jumpQueued = false;
    }
    }

    public void MovePlayer(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            movementInput = context.ReadValue<Vector2>();
            if(movementInput.x < 0) {
                transform.localRotation = Quaternion.Euler(new Vector3(0,180,0));
                                Debug.Log("karakter döndü");}
            else if(movementInput.x > 0) {
                transform.localRotation = Quaternion.Euler(new Vector3(0,0,0));
                Debug.Log("karakter döndü");
                }


        }
        else if (context.canceled)
        {
            movementInput = new Vector2(0,body2d.velocity.y);
        }
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
    public void JumpAction(float multiplier){
        body2d.velocity = new Vector2(body2d.velocity.x, JumpForce*multiplier);
        SoundfxManager.instance.PlaySoundFX(playerJumpFX,transform);
        lockXScale();
    }
    private void lockXScale(){
        isScaleLocked = true;
        lockedX = transform.localRotation;
    }
    private void unlockXScale(){
        isScaleLocked = false;
    }
    private void LateUpdate()
    {
        if(isScaleLocked) transform.localRotation = lockedX;
        else{
            if(body2d.velocity.x < 0) transform.localRotation = Quaternion.Euler(new Vector3(0,180,0));
            else if(body2d.velocity.x > 0) transform.localRotation = Quaternion.Euler(new Vector3(0,0,0));
        }
    }
}
