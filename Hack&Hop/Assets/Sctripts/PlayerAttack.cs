using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float phoneVelocity = 2f;
    public float Damage = 10f;
    public float attackInterval = 0.5f;
    public AudioClip attackClip;
    [SerializeField] private UnityEventList unityEventList;
    [SerializeField] private GameObject attackItem;
    [SerializeField] private GameObject attackLocation;
    private PlayerItemManager playerItemManager;
    private float lastAttackTime = 0f;
    void Start()
    {
        playerItemManager = GetComponent<PlayerItemManager>();
    }
    public void Attack(){
        if(!playerItemManager.isPhoneAvaible) return;
        if(lastAttackTime >= Time.time) return;
        lastAttackTime = Time.time +attackInterval;
        GameObject newPhone = Instantiate(attackItem, attackLocation.transform.position, Quaternion.identity);
        if(newPhone.TryGetComponent<Rigidbody2D>(out Rigidbody2D rigidbody)){
            int val = 1;
            if(transform.localRotation.eulerAngles.y == 180) val = -1;
            rigidbody.AddForce(new Vector2(val*phoneVelocity,0));
            SoundfxManager.instance.PlaySoundFX(attackClip,transform);
        }
        unityEventList.playerAttacked.Invoke();

    }
}
