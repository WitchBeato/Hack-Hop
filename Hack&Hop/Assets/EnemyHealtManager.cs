using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class EnemyHealtManager : NPCHealtSystem
{
    public override void NPCDeath()
    {
        base.NPCDeath();
        Destroy(gameObject);
    }
}
