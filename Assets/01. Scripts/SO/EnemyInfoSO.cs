using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/EnemyInfoSO")]
public class EnemyInfoSO : ScriptableObject
{
    public int maxHealth;
    public int killReward;
}
