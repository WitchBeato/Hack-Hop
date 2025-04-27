using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrenchGiveUpgrade : AltarColliderManager
{
    public override void GetItem()
    {
        Debug.Log("get item");
        GameObject.Find("MC").TryGetComponent<PlayerItemManager>(out PlayerItemManager manager);
            GoodTools tools = GetComponent<AltarDataSctript>().powerUpTool;
            manager.unlockPlayerItem(tools);
    }
}
