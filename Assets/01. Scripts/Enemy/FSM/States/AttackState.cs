using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : EnemyState
{
    private float currentAttackTime;

    public override void StartAction()
    {
        Debug.Log("Enemy Attack");

        controller.GetComponent<IEnemyAttack>().Attack();    
    }

    public override void UpdateAction()
    {
        if(EndOfAttack())
        {
            controller.ChangeState<MoveState>();
        }
    }

    public override void EndAction()
    {
         currentAttackTime = 0f; 
    }

    private bool EndOfAttack()
    {
        currentAttackTime += Time.deltaTime;

        if(currentAttackTime >= controller.info.attackTime)
        {
            return true;
        }  

        return false;
    }
}