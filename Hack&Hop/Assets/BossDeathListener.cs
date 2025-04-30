using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeathListener : MonoBehaviour
{
    void Start()
    {
        UnityEventList.instance.bossDeath.AddListener(bossDeath);
        gameObject.SetActive(false);
    }
    public void bossDeath(){
        gameObject.SetActive(true);
    }
}
