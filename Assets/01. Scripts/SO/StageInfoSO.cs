using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageSO", menuName = "SO/StageSO")]
[System.Serializable]
public class StageInfoSO : ScriptableObject
{
    public int stageIndex;
    public Sprite stageBackground;
    public EnemyList[] enemyList = new EnemyList[20];
}
[System.Serializable]
public class EnemyList
{
    public EnemyController[] enemies = new EnemyController[9];
}

