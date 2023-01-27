using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState
{
    protected EnemyBrain brain;

    public void SetBrain(EnemyBrain _brain) 
    {
        brain = _brain;
    }

    public abstract void StartAction();

    public abstract void UpdateAction();

    public abstract void EndAction();
}
