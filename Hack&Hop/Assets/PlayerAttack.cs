using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float phoneVelocity = 2f;
    [SerializeField] private GameObject attackItem;
        [SerializeField] private GameObject attackLocation;
    public void Attack(){
        GameObject newPhone = Instantiate(attackItem, attackLocation.transform.position, Quaternion.identity);
        if(newPhone.TryGetComponent<Rigidbody2D>(out Rigidbody2D rigidbody)){
            rigidbody.AddForce(new Vector2(transform.localScale.x*phoneVelocity,0));
        }

    }
}
