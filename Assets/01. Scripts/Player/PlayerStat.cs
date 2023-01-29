using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct StatInfo
{
    public Stat stat;
    public float value;
}

public class PlayerStat : MonoBehaviour
{
    /// <summary>
    /// 초기 스탯
    /// </summary>
    [SerializeField] List<StatInfo> initalStats = new List<StatInfo>();    
    private Dictionary<Stat, float> stats = new Dictionary<Stat, float>();

    /// <summary>
    /// 스탯 읽기용 인덱서
    /// </summary>
    public float this[Stat stat] => stats[stat];

    private void Awake()
    {
        foreach(StatInfo sInfo in initalStats)
            CreateStat(sInfo);
    }

    /// <summary>
    /// 스탯 딕셔너리 생성
    /// </summary>
    private void CreateStat(StatInfo info)
    {
        if(stats.ContainsKey(info.stat))
        {
            Debug.LogWarning($"{info.stat}, current stat already exist on stats, returning");
            return;
        }

        stats.Add(info.stat, info.value);
    }

    /// <summary>
    /// 스택 증가 및 감소
    /// </summary>
    public void SetStat(Stat stat, float amount)
    {
        if(!stats.ContainsKey(stat))
        {
            Debug.LogWarning($"{stat}, current stat doesnt exist on stats, returning");
            return;
        }

        stats[stat] += amount;
    }
}