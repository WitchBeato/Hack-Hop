using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaveManager : MonoBehaviour
{
    public AudioClip saveFX;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<PlayerEnterSave>(out PlayerEnterSave component)){
            component.enter();
            SoundfxManager.instance.PlaySoundFX(saveFX,transform);
        }
    }

}
