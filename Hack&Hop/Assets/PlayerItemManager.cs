using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerItemManager : MonoBehaviour
{
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
        if(currentItem.UseItem.TryGetComponent<IUseItem>(out IUseItem useitem) 
        &&callbackContext.performed){
            useitem.use();
        }
    }

}
