using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : EnemyState
{
    private Movement mover;
    private Animator animator;
    private float currentAttackTime;

    public override void StartAction()
    {
        Debug.Log("Enemy Move");

        mover = controller.GetComponent<Movement>();
        animator = controller.GetComponent<Animator>();
    }

    public override void UpdateAction()
    {
        Move();

        if(IsAttackTime())
        {
            if(IsAttackRange())
            {
                controller.ChangeState<AttackState>();
            }
        }
    }

    public override void EndAction()
    {
        mover.StopImmediately();
        currentAttackTime = 0f;
    }

    private void Move()
    {
        if(!IsAttackRange())
        {
            mover.MoveTo(GetMoveDirection());
            animator.SetInteger("MoveState", 1);
            
        }
        else
        {
            mover.StopImmediately();
            animator.SetInteger("MoveState", 0);
        }

        Flip();
    }

    private Vector2 GetMoveDirection()
    {
        return (controller.target.transform.position - controller.transform.position).normalized;
    }

    private bool IsAttackTime()
    {
        currentAttackTime += Time.deltaTime;

        if(currentAttackTime >= controller.info.attackDelayTime)
        {
            return true;
        }

        return false;
    }

    private bool IsAttackRange()
    {
        return Vector2.Distance(controller.body.transform.position, controller.target.transform.position) <= controller.info.attackDistance;
    }

    private void Flip()
    {
        if(controller.transform.position.x > controller.target.transform.position.x)
        {
            controller.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            controller.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}