using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AltarColliderManager : MonoBehaviour
{
    public IAltarManager altarManager;
    private GameObject realPlayer;
    private GameObject fakePlayer;
    public GameObject getItemPlayer;
    public AltarVisualManager visualManager;
    private PlayerInput playerInput;
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }
    void Start()
    {
        altarManager = GetComponent<IAltarManager>();
        
        realPlayer = GameObject.Find("MC");
        setInputActive(false);
    }
void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.gameObject != realPlayer) return; // Sadece gerçek oyuncuya izin ver.
    GetItem();

    realPlayer = collision.gameObject; // İlk kez çarpan oyuncuyu kaydet.
    Debug.Log(altarManager);
    altarManager.getItem();
    visualManager.setSpriteVisible(false);

    // Önce Collider'ı disable et
    Collider2D playerCollider = realPlayer.GetComponent<Collider2D>();
    if (playerCollider != null)
        playerCollider.enabled = false;

    realPlayer.SetActive(false); // Oyuncuyu sahneden kaldır.
    
    fakePlayer = Instantiate(getItemPlayer, transform.position, Quaternion.identity); // Yeni obje yarat.
    
    visualManager.setTextVisible(true);
    setInputActive(true);
}
public virtual void GetItem(){

}
public void continuetoYourJourner(InputAction.CallbackContext callbackContext){
    if(callbackContext.performed){
        Vector2 local = fakePlayer.transform.position;
        Destroy(fakePlayer);
        realPlayer.transform.position =local;
        realPlayer.SetActive(true);
        Collider2D playerCollider = realPlayer.GetComponent<Collider2D>();
        playerCollider.enabled = true;
        setInputActive(false);
        Destroy(gameObject);
    }
}
private void setInputActive(bool isTrue){
    playerInput.enabled = isTrue;
}

}
