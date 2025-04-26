using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerItemManager : MonoBehaviour
{
    public bool isPhoneAvaible;
    public PlayerItem currentItem {private set; get;}
    private int currentItemID = 0;
    [SerializeField] private PlayerItem[] PlayerItemList;
    void Start()
    {
        currentItem = PlayerItemList[0];
    }

    public void ChangeItem(Vector2 change){
        int changeValue = (int)change.x;
        currentItemID += changeValue;
        if(currentItemID < 0) currentItemID = PlayerItemList.Length-1;
        if(currentItemID >= PlayerItemList.Length) currentItemID = 0;
        currentItem = PlayerItemList[currentItemID];
    }
    public void useItem(InputAction.CallbackContext callbackContext){
        if(!callbackContext.performed) return;
        if(currentItem.UseItem.TryGetComponent<IUseItem>(out IUseItem useitem) && currentItem.isAvaible){
            useitem.use();
        }
    }
    public void unlockPlayerItem(GoodTools item){
        for(int i = 0; i < PlayerItemList.Length; i++){
            if(PlayerItemList[i].goodTools == item) 
            PlayerItemList[i].isAvaible = true;
        }

    }
    public void unlockPhone(){
        isPhoneAvaible = true;
    }

}
