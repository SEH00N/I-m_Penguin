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
    [SerializeField] List<StatInfo> initalStats = new List<StatInfo>();    
    private Dictionary<Stat, float> stats = new Dictionary<Stat, float>();

    public float this[Stat stat] => stats[stat];

    private void Awake()
    {
        foreach(StatInfo sInfo in initalStats)
            CreateStat(sInfo);
    }

    private void CreateStat(StatInfo info)
    {
        if(stats.ContainsKey(info.stat))
        {
            Debug.LogWarning($"{info.stat}, current stat already exist on stats, returning");
            return;
        }

        stats.Add(info.stat, info.value);
    }

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