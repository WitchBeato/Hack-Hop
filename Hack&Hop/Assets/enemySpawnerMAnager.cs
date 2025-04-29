using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawnerMAnager : MonoBehaviour
{
    public GameObject enemyprefab;
    public GameObject enemy;
    void Start()
    {
        StartCoroutine(DelayedSpawn());
    }
    IEnumerator DelayedSpawn(){
    yield return null; // wait one frame
        UnityEventList.instance.loadGame.AddListener(SpawnEnemies);
        SpawnEnemies();
}
    public void SpawnEnemies(){
        if(enemy != null){
            if(!enemy.GetComponent<NPCHealtSystem>().IsDeath) enemyNotDeath();
        }
        enemy = Instantiate(enemyprefab,transform.position,Quaternion.identity);
    }
    public virtual  void enemyNotDeath(){
        return;
        }
}
