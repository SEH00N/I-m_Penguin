using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : EnemyState
{
    private Movement mover;

    public override void StartAction()
    {
        Debug.Log("Enemy Move");

        mover = brain.GetComponent<Movement>();
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
        return (brain.target.transform.position - brain.transform.position).normalized;
    }
}