using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushUpgradeManager : MonoBehaviour, IUseItem
{
    public float mesafe = 0.5f;
    public AudioClip useFX;
    private MCAnimationManager mcAnimationManager;
    [SerializeField]private GameObject attackLocation;
    void Awake()
    {

    }
    void Start()
    {
        mcAnimationManager = FindObjectOfType<MCAnimationManager>();
    }
    public void use()
    {
        Transform playerloc = GameObject.Find("MC").transform;
        int val = 1;
        if(playerloc.localRotation.eulerAngles.y == 180) val = -1;
        RaycastHit2D hit = Physics2D.Raycast(attackLocation.transform.position,Vector2.right*val,mesafe);
        if(hit.collider.gameObject.TryGetComponent<PushableObject>(out PushableObject component)){
            SoundfxManager.instance.PlaySoundFX(useFX,transform);
            component.PushObject();
        }
    }
}
