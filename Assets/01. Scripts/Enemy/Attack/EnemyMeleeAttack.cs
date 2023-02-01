using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : EnemyAttack
{
    public Transform attackPosition;

    public override void Attack()
    {
        MeleeAttack();
    }

    protected override void MeleeAttack()
    {
        Collider2D hit = Physics2D.OverlapCircle(attackPosition.position, info.meleeAttackRangeRadius, 1 << 8);

        if(hit)
        {
            IDamageable player;

            if(hit.TryGetComponent<IDamageable>(out player))
            {
                //player.OnDamage(info.meleeAttackPower);
                Debug.Log(1);
            }
        }
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
    
        Gizmos.DrawWireSphere(attackPosition.position, 1f);
    }
}
