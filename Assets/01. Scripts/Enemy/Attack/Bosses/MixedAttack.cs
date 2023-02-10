using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixedAttack : EnemyAttack
{
    public Projectile projectile;
    public float boundaryDistance;
    public Transform firePosition;

    public override void Attack()
    {
        if(GetDistance() <= boundaryDistance)
        {
            MeleeAttack();
        }
        else
        {
            RangeAttack();
        }
    }

    private void MeleeAttack()
    {
        Collider2D hit = Physics2D.OverlapCircle(attackPosition.position, info.meleeAttackRangeRadius, 1 << 8);

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

    private void RangeAttack()
    {
        Vector2 dir = GameObject.FindWithTag("Player").transform.position - firePosition.position;
        Debug.Log(dir);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Debug.Log(angle);

        GameObject.Instantiate(projectile, firePosition.position, Quaternion.Euler(0, 0, angle), transform);//풀로 변경
    }
}
