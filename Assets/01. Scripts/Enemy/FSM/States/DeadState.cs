using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : EnemyState
{
    public override void StartAction()
    {
        Debug.Log($"{controller.name} is dead");
    }

    public override void UpdateAction()
    {
        
    }

    public override void EndAction()
    {
        
    }
}
