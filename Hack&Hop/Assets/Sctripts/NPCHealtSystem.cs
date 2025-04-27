using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHealtSystem : MonoBehaviour, INPCHealt
{
    public float maxHP;
    public float CurrentHP;
    public float damageRedTime = 0.3f;
    public bool IsDeath{
    get 
    {return isDeath;}
    set {
        isDeath = value;
    }}
    private bool isDeath = false;
    [SerializeField] private SpriteRenderer spriteRenderer;
    void Start()
    {
        if(gameObject.TryGetComponent<SpriteRenderer>(out SpriteRenderer spriteRenderer)){
            this.spriteRenderer = spriteRenderer;
        }
    }
    public virtual void getAttack(float value)
    {
        CurrentHP -= value;
        if(CurrentHP <= 0) setHP(0);
        else setHP(CurrentHP);
        StartCoroutine(takeDamageChange());
        isDeath = true;
    }

    public virtual void  setHP(float value)
    {
        CurrentHP = value;
    }

    public virtual void setMaxHP(float value)
    {
        maxHP = value;
    }
    private IEnumerator takeDamageChange()
    {
        Color originalColor = spriteRenderer.color;

        // Rengi kırmızı yap
        spriteRenderer.color = Color.red;

        // 0.2 saniye bekle
        yield return new WaitForSeconds(damageRedTime);

        // Eski rengine geri dön
        spriteRenderer.color = originalColor;

        // Geri kalan invulnerability süresini bekle
    }
}
