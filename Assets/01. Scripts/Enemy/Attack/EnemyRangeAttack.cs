using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeAttack : EnemyAttack
{
    public Projectile projectile;

    public override void Attack()
    {
        RangeAttack();
    }

    private void RangeAttack()
    {
        Vector2 dir = GameObject.FindWithTag("Player").transform.position - attackPosition.position;
        Debug.Log(dir);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Debug.Log(angle);

        GameObject.Instantiate(projectile, attackPosition.position, Quaternion.Euler(0, 0, angle), transform);//풀로 변경
    }
}
