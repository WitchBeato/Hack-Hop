using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrenchGiveUpgrade : MonoBehaviour, IAltarManager
{
    public void getItem()
    {
        Debug.Log("get item");
        GameObject.Find("MC").TryGetComponent<PlayerItemManager>(out PlayerItemManager manager);
            GoodTools tools = GetComponent<AltarDataSctript>().powerUpTool;
            manager.unlockPlayerItem(tools);
    }

    public void giveDescription()
    {
        throw new System.NotImplementedException();
    }
}
