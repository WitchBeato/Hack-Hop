using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealtManager : EnemyHealtManager
{
    public Slider slider;
    void Start()
    {
            UnityEventList.instance.playerDeath.AddListener(bossHealtMakeAgain);
            slider.maxValue = maxHP;
            slider.value = CurrentHP;
    }
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
    float animconstant = 1/3;
    UnityEventList.instance.bossDeath.Invoke();
    
    yield return new WaitForSeconds(deathAnimLength*animconstant);
    base.NPCDeath();
}
private void bossHealtMakeAgain(){
    Debug.Log("okundu");
    setHP(maxHP);
}
    public override void setHP(float value)
    {
        base.setHP(value);
        slider.value = CurrentHP;
        
    }

}
