using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttack : MonoBehaviour
{
    protected EnemyInfoSO info;

    private void Start() 
    {
        info = GetComponent<EnemyInfo>().enemyInfo;
    }
    
    public abstract void Attack();
    protected virtual void MeleeAttack() {}
    protected virtual void RangeAttack() {}
}
