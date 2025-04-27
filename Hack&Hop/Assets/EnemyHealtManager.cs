using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class EnemyHealtManager : NPCHealtSystem
{
    public AudioClip enemyDeathFX;
    public override void NPCDeath()
    {
        base.NPCDeath();
        SoundfxManager.instance.PlaySoundFX(enemyDeathFX,transform);
        Destroy(gameObject);

    }
}
