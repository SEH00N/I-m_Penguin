using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    public int CurrentHp => currentHp;
    public int MaxHp => maxHp;

    private int currentHp;
    private int maxHp;

    private void Start() 
    {
        maxHp = GetComponent<EnemyInfo>().enemyInfo.maxHealth;
        currentHp = MaxHp;
    }

    public void OnDamage(int damage, Action callback = null)
    {
        currentHp = Mathf.Max(currentHp - damage, 0);

        if(currentHp == 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GetComponent<EnemyEventHandler>().DieAction?.Invoke();
    }
}
