using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnManager : enemySpawnerMAnager
{
    public override void  enemyNotDeath(){
        NPCHealtSystem healtSystem = enemy.GetComponent<NPCHealtSystem>();
        healtSystem.setHP(healtSystem.maxHP);
    }
}
