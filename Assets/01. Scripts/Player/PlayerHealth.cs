using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] int maxHp;
    private int currentHp = 0;

    public int CurrentHp => currentHp;
    public int MaxHp => maxHp;

    public void OnDamage(int damage, Action callback = null)
    {
        currentHp -= damage;
        HitEffect(damage);

        callback?.Invoke();

        if(currentHp <= 0)
            OnDie();
    }

    /// <summary>
    /// 치유 메소드
    /// </summary>
    public void Heal(int amount)
    {
        currentHp += amount;
        currentHp = Mathf.Min(currentHp, maxHp);

        HealEffect(amount);
    }

    /// <summary>
    /// 치유 이펙트
    /// </summary>
    private void HealEffect(int amount)
    {

    }

    /// <summary>
    /// 맞았을 때 이펙트
    /// </summary>
    private void HitEffect(int damage)
    {
        
    }

    /// <summary>
    /// 죽었을 때 실행되는 메소드
    /// </summary>
    private void OnDie()
    {

    }

    /// <summary>
    /// 죽을 때 이펙트
    /// </summary>
    private void DieEffect()
    {
        
    }
}
