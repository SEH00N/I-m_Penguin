using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(EnemyHealth))]
[RequireComponent(typeof(EnemyEventHandler))]
[RequireComponent(typeof(EnemyInfo))]
public class EnemyController : MonoBehaviour
{    
    public EnemyState currentState;
    public GameObject target;
    [HideInInspector] public EnemyInfoSO info;

    private Dictionary<Type, EnemyState> stateList = new Dictionary<Type, EnemyState>();

    void Start()
    {
        Init();
    }
    
    void Update()
    {
        currentState.UpdateAction();
    }    

    public void SetTarget(GameObject _target)
    {
        if (_target == null) return;

        target = _target;
    }

    private void Init()
    {
        info = GetComponent<EnemyInfo>().enemyInfo;

        AddState(new MoveState());
        AddState(new AttackState());
        AddState(new DeadState());

        currentState = GetState<MoveState>();
        currentState.StartAction();

        SetTarget(GameObject.FindObjectOfType<Player>().gameObject);
    }

    #region FSM
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

    private void AddState(EnemyState state)
    {
        stateList.Add(state.GetType(), state);
        state.SetController(this);
    }
    #endregion
}
