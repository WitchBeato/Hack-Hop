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
            applyKnockback(collision.gameObject);
            SoundfxManager.instance.PlaySoundFX(boomFX,transform);
        }
        Instantiate(phoneBoom, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    private void applyKnockback(GameObject enemy){
        if(enemy.TryGetComponent<KnockbackManager>(out KnockbackManager component)){
            Vector2 position = enemy.transform.position - transform.position;
            position = position.normalized;
            position = new Vector2(position.x,position.y);  
            Debug.Log(position);
            component.ApplyKnockback(position,10f);
        }
    }
}
