using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerItemManager : MonoBehaviour
{
    public UnityEngine.UI.Image toolImageonCanva;
    public bool isPhoneAvaible;
    public PlayerItem currentItem {private set; get;}
    private int currentItemID = 0;
    [SerializeField] private PlayerItem[] PlayerItemList;
    void Start()
    {
        currentItem = PlayerItemList[0];
        setToolImage(null);
    }
    public void changeItem(InputAction.CallbackContext context){
    if (!context.performed) return;
    this.ChangeItem(context.ReadValue<Vector2>());
    }
    public void ChangeItem(Vector2 change){
        int changeValue = (int)change.x;
        currentItemID += changeValue;
        if(currentItemID < 0) currentItemID = PlayerItemList.Length-1;
        if(currentItemID >= PlayerItemList.Length) currentItemID = 0;
        currentItem = PlayerItemList[currentItemID];
        setToolImage(currentItem.goodTools.sprite);
    }
    public void setToolImage(Sprite sprite){
    if (sprite == null) // Use '==' for comparison
    {
        toolImageonCanva.gameObject.SetActive(false); // Hide the image if sprite is null
    }
    else
    {
        toolImageonCanva.gameObject.SetActive(true); // Show the image if sprite is not null
        toolImageonCanva.sprite = sprite; // Set the sprite
    }
    }
    public void useItem(InputAction.CallbackContext callbackContext){
        if(!callbackContext.performed) return;
        if(currentItem.UseItem.TryGetComponent<IUseItem>(out IUseItem useitem) && currentItem.isAvaible){
            useitem.use();
        }
    }
    public void Save(){
        PlayerData data = GetComponent<PlayerData>();
        data.isPhoneAvaible = isPhoneAvaible;
        data.playerItem = PlayerItemList;
    }
    public void load(PlayerData data){
        isPhoneAvaible = data.isPhoneAvaible;
        PlayerItemList = data.playerItem;
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
