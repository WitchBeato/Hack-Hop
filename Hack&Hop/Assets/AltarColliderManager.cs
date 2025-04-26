using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarColliderManager : MonoBehaviour
{
    private IAltarManager altarManager;
    private GameObject realPlayer;
    public GameObject getItemPlayer;
    public AltarVisualManager visualManager;
    // Start is called before the first frame update
    void Start()
    {
        altarManager = GetComponent<IAltarManager>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        visualManager.setSpriteVisible(false);
        realPlayer = collision.gameObject;
        realPlayer.SetActive(false);
        Instantiate(getItemPlayer,collision.transform.position,Quaternion.identity);
        visualManager.setTextVisible(true);

    }
}
