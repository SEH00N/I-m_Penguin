using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{  
    public Dictionary<Type, EnemyState> stateList = new Dictionary<Type, EnemyState>();
    public EnemyState currentState;

    void Start()
    {
        Init();
    }

    
    void Update()
    {
        currentState.UpdateAction();
    }

    public void ChangeState<T>() where T : EnemyState
    {
        if(currentState.GetType() == typeof(T) || !stateList.ContainsKey(typeof(T)))
            return;

        currentState.EndAction();
        currentState = stateList[typeof(T)];
        currentState.StartAction();
    }

    public EnemyState GetState<T>() where T : EnemyState
    {
        return stateList[typeof(T)];
    }

    private void Init()
    {
        AddState(new MoveState());
        AddState(new AttackState());
        AddState(new DeadState());

        currentState = GetState<MoveState>();
        currentState.StartAction();
    }

    private void AddState(EnemyState state)
    {
        stateList.Add(state.GetType(), state);
        state.SetBrain(this);
    }
}
