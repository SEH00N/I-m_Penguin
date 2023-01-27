using System.IO;
using System;

public interface IDamageable
{
    public int CurrentHp { get; }
    public int MaxHp { get; }

    public void OnDamage(int damage, Action callback = null);
}
