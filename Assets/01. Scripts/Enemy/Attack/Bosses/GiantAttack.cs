using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantAttack : EnemyAttack
{
    public float shockDistance;
    public int shockPower;

    public override void Attack()
    {
        MeleeAttack();
    }

    private void MeleeAttack()
    {
        Collider2D hit = Physics2D.OverlapCircle(attackPosition.position, info.meleeAttackRangeRadius, 1 << 8);

        if(GetDistance() <= shockDistance)
        {
            GameObject.FindWithTag("Player").GetComponent<IDamageable>().OnDamage(shockPower);
        }

        if (hit)
        {
            IDamageable player;

            if (hit.TryGetComponent<IDamageable>(out player))
            {
                //player.OnDamage(info.meleeAttackPower);
                Debug.Log(1);
            }
        }
    }
}
