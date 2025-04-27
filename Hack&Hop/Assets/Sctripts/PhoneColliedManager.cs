using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneColliedManager : MonoBehaviour
{
    private PlayerThrowManager playerThrowManager;
    public AudioClip boomFX;
    void Start()
    {
        playerThrowManager = GetComponent<PlayerThrowManager>();
    }
    [SerializeField] private GameObject phoneBoom;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player"){        
            return;
        }
        if(collision.gameObject.TryGetComponent<EnemyHealtManager>(out EnemyHealtManager manager)){
            manager.getAttack(playerThrowManager.Damage);
            SoundfxManager.instance.PlaySoundFX(boomFX,transform);
        }
        Instantiate(phoneBoom, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
