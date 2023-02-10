using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class StageManager : MonoBehaviour
{
    public int stageIndex = 1;
    public int stageLevel = 0;
    public StageInfoSO StageInfo;
    public Transform[] enemySpanwPoints = new Transform[9];

    private void Awake()
    {
        StageInfo = Resources.Load<StageInfoSO>($"SO/Stage/Stage{stageIndex}");
    }

    private void Start()
    {
        SpawnEnemy();
        GameObject.Find("Square").GetComponent<SpriteRenderer>().sprite = StageInfo.stageBackground;
    }

    private void SpawnEnemy()
    {
        for(int i = 0; i < enemySpanwPoints.Length; i++)
        {
            if(StageInfo.enemyList[stageLevel].enemies[i] != null)
            {
                GameObject.Instantiate(StageInfo.enemyList[stageLevel].enemies[i], enemySpanwPoints[i].position, Quaternion.identity, transform);
            }
        }

        stageLevel++;
    }
}
