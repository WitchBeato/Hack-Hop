using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneColliedManager : MonoBehaviour
{
    [SerializeField] private GameObject phoneBoom;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player"){        
            return;
        }
        Instantiate(phoneBoom, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
