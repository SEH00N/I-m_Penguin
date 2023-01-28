using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : EnemyState
{
    private Movement mover;

    public override void StartAction()
    {
        Debug.Log("Enemy Move");

        mover = controller.GetComponent<Movement>();
    }

    public override void UpdateAction()
    {
        mover.MoveTo(GetMoveDirection());
    }

    public override void EndAction()
    {
        mover.StopImmediately();
    }

    private Vector2 GetMoveDirection()
    {
        return (controller.target.transform.position - controller.transform.position).normalized;
    }
}