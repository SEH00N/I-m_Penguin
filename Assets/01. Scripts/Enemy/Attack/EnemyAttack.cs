using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttack : MonoBehaviour
{
    protected EnemyInfoSO info;
    public Transform attackPosition;
    public float meleeAttackRange = 1f;//EnemySO�� �ִ� ���� �����ϰ� ����, rangeAttack�� 0����

    private void Start()
    {
        info = GetComponent<EnemyInfo>().enemyInfo;
    }

    public abstract void Attack();

    protected float GetDistance()
    {
        return Vector2.Distance(GameObject.FindWithTag("Player").transform.position, transform.position);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(attackPosition.position, meleeAttackRange);
    }
}
