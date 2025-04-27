using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEnterSave : MonoBehaviour
{
    public UnityEventList unityEventList;
    public void enter(){
        unityEventList.playerSaveGame.Invoke();
    }
}
