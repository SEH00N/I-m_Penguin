using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/EnemyInfoSO")]
public class EnemyInfoSO : ScriptableObject
{
    public int maxHealth;
    public int killReward;
    public float meleeAttackRangeRadius;//공격 범위
    public float attackDistance;//공격을 하기 위해 필요 거리
    public int meleeAttackPower;
    public int rangeAttackPower;
    public float attackTime;//공격 시간
    public float attackDelayTime;//공격을 하기 위해 필요한 시간
}
