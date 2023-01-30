using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttack : MonoBehaviour
{
    public float meleeAttackPower;
    public float rangeAttackPower;
    public float meleeAttackTime;
    public float rangeAttackTime;

    public abstract void MeleeAttack();
    public virtual void RangeAttack() {}
}