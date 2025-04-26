using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneUpgradeUnlocker : MonoBehaviour,IAltarManager
{
    public void getItem()
    {
        Debug.Log("hm");
        if(GameObject.Find("MC").TryGetComponent<PlayerItemManager>(out PlayerItemManager playerItem)){
            Debug.Log("hm");
            playerItem.unlockPhone();
        }

    }

    public void giveDescription()
    {
        throw new System.NotImplementedException();
    }


}
