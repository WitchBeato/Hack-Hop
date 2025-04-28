using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawnerMAnager : MonoBehaviour
{
    public GameObject enemyprefab;
    public GameObject enemy;
    void Start()
    {
        UnityEventList.instance.loadGame.AddListener(SpawnEnemies);
        SpawnEnemies();
    }
    public void SpawnEnemies(){
        if(enemy != null){
            if(!enemy.GetComponent<NPCHealtSystem>().IsDeath) return;
        }
        enemy = Instantiate(enemyprefab,transform.position,Quaternion.identity);
    }
}
