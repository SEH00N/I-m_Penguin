using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class EnemyState
{
    protected EnemyController controller;

    public void SetController(EnemyController _controller) 
    {
        controller = _controller;
    }

    public abstract void StartAction();

    public abstract void UpdateAction();

    public abstract void EndAction();
}
