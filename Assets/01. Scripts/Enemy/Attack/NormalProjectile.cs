using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalProjectile : Projectile
{
    protected override void TakeDamage(IDamageable target)
    {
        target.OnDamage(5);       
    }
}
