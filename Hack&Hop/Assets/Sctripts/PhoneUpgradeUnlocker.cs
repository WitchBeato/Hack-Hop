using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneUpgradeUnlocker : AltarColliderManager
{
    public override void GetItem(){
        if(GameObject.Find("MC").TryGetComponent<PlayerItemManager>(out PlayerItemManager itemManager)){
            itemManager.unlockPhone();
        }
    }


}
