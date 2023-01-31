using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour, IEnemyAttack
{
    public Vector2 attackOffset;

    private EnemyEventHandler enemyEvent;
    private float meleeAttackRangeRadius;

    private void Start() 
    {
        enemyEvent = GetComponent<EnemyEventHandler>();    
        meleeAttackRangeRadius = GetComponent<EnemyInfo>().enemyInfo.meleeAttackRangeRadius;
    }

    public void Attack()
    {
        enemyEvent.attackAction?.Invoke();
    }

    public void MeleeAttack()
    {
        Collider2D hit = Physics2D.OverlapCircle((Vector2)transform.right + new Vector2(meleeAttackRangeRadius * 0.5f, 0) + attackOffset, 
            meleeAttackRangeRadius, 1 << 8);

        if(hit)
        {
            Debug.Log("hit");
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere((Vector2)transform.right + new Vector2(meleeAttackRangeRadius * 0.5f, 0) + attackOffset, 
            0.5f);
    }
}