using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealtManager : NPCHealtSystem
{
    public float invulnerabilityDuration = 2f;
    [SerializeField]private TMP_Text text;
    [SerializeField]private Slider healtSlider;
    private bool isInvulnerable = false;


    void Start()
    {
        healtSlider.maxValue = maxHP;
        healtSlider.value = CurrentHP;
        text.SetText(((int)CurrentHP).ToString());
    }
    public override void setHP(float value){
        healtSlider.value = value;
        text.SetText(((int)value).ToString());
        base.setHP(value);
    }
    public override void getAttack(float value){
        if(isInvulnerable) return;
        base.getAttack(value);
        Debug.Log(value);
        StartCoroutine(StartInvulnerability());
    }
    public override void setMaxHP(float value){
        healtSlider.maxValue = value;
        base.setMaxHP(value);
    }
        private IEnumerator StartInvulnerability()
    {
        isInvulnerable = true;
        Debug.Log("Dokunulmazlık başladı!");

        yield return new WaitForSeconds(invulnerabilityDuration);

        isInvulnerable = false;
        Debug.Log("Dokunulmazlık bitti!");
    }
}
