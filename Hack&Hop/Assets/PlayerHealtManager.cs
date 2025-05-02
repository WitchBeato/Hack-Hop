using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealtManager : NPCHealtSystem
{
    public float invulnerabilityDuration = 2f;
    public AudioClip deathFX;
    
    [SerializeField]private UnityEventList unityEventList;
    [SerializeField]private TMP_Text text;
    [SerializeField]private Slider healtSlider;
    private bool isInvulnerable = false;


    void Start()
    {
        healtSlider.maxValue = maxHP;
        healtSlider.value = CurrentHP;
        text.SetText(((int)CurrentHP).ToString());
        UnityEventList.instance.playerSaveGame.AddListener(yazdostum);
    }
    public override void setHP(float value){
        base.setHP(value);
        healtSlider.value = value;
        Debug.Log("can: "+ value);
        text.SetText(((int)value).ToString());
    }
    public override void getAttack(float value){
        if(isInvulnerable) return;
        base.getAttack(value);
        StartCoroutine(StartInvulnerability());
    }
    public override void setMaxHP(float value){
        base.setMaxHP(value);
        healtSlider.maxValue = value;
    }
        private IEnumerator StartInvulnerability()
    {
        isInvulnerable = true;

        yield return new WaitForSeconds(invulnerabilityDuration);

        isInvulnerable = false;
    }
    public override void NPCDeath()
    {
        unityEventList.playerDeath.Invoke();
        UnityEventList.instance.playerDeath.Invoke();
        SoundfxManager.instance.PlaySoundFX(deathFX,transform);
        UnityEventList.instance.loadGame.Invoke();
        base.NPCDeath();
    }
    public void yazdostum(){
    }
}
