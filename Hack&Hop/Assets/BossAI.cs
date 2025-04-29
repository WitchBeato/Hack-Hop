using System.Collections;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    private Coroutine attackRoutine;
    public float attackInterval = 2f; // Attacks every 2 seconds
    private IBossAttack[] attacks;

    void Awake()
    {
        // Initialize attacks
        attacks = new IBossAttack[]
        {
            new BossAttackMissives(),
            new BossAttackWhip(),
            new StandStill() // Changed to PascalCase for naming convention
        };
    }

    private void Start()
    {
        attackRoutine = StartCoroutine(AttackRoutine());
    }

    private IEnumerator AttackRoutine()
    {
        while (true)
        {
            ExecuteRandomAttack();
            yield return new WaitForSeconds(attackInterval);
        }
    }

    private void ExecuteRandomAttack()
    {
        if (attacks.Length == 0) return;
        
        int randomIndex = Random.Range(0, attacks.Length);
        attacks[randomIndex].Attack();
    }

    private void OnDisable()
    {
        StopAttacking();
    }

    public void StopAttacking()
    {
        if (attackRoutine != null)
        {
            StopCoroutine(attackRoutine);
            attackRoutine = null;
        }
    }
}

// Example attack implementations
public class BossAttackMissives : IBossAttack
{
    public void Attack()
    {
        Debug.Log("Launching missives attack!");
        BossAttackManager.instance.AttackWhip();
    }
}

public class BossAttackWhip : IBossAttack
{
    public void Attack()
    {
        Debug.Log("Whipping attack!");
        BossAttackManager.instance.AttackRocket();
    }
}

public class StandStill : IBossAttack
{
    public void Attack()
    {
        Debug.Log("Boss is standing still");
        // No attack logic
    }
}
