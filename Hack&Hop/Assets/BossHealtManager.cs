using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealtManager : EnemyHealtManager
{
 public override void NPCDeath()
{
    BossAnimationManager.instance.playDeathAnim();
    StartCoroutine(DelayedDeath());
}

private IEnumerator DelayedDeath()
{
    // Get the length of the death animation
    AnimatorClipInfo[] clipInfo = BossAnimationManager.instance.giveLenght();
    float deathAnimLength = clipInfo[0].clip.length;
    
    yield return new WaitForSeconds(deathAnimLength);
    base.NPCDeath();
}
}
