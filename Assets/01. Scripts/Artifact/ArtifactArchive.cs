using System.Collections.Generic;
using UnityEngine;

public class ArtifactArchive : MonoBehaviour
{
    //이미 장착하고 있는 유물이나 장비 같은 경우엔 제거 후 업그레이드 된 걸 다시 장착하면 됨

    [SerializeField] Dictionary<string, Artifact> artifactList = new Dictionary<string, Artifact>();

    private Player player = null;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    /// <summary>
    /// 유물 장착
    /// </summary>
    /// <param name="artifact"></param>
    public void EquipArtifact(Artifact artifact)
    {
        artifactList.Add(artifact.ArtifactName, artifact);

        OnArtifactEquip(artifact);
    }

    /// <summary>
    /// 유물 제거
    /// </summary>
    /// <param name="artifactName"></param>
    public void UnequipArtifact(string artifactName)
    {
        if(!artifactList.ContainsKey(artifactName))
        {
            Debug.LogWarning("curernt name of artifact doesnt existed on dictionary, returning");
            return;
        }

        artifactList.Remove(artifactName, out Artifact removedArtifact);

        OnArtifactUnequip(removedArtifact);
    }

    /// <summary>
    /// 장착 이펙트
    /// </summary>
    /// <param name="artifact"></param>
    private void OnArtifactEquip(Artifact artifact) 
    {
        artifact.MountingEffect.ForEach(statInfo => {
            player.PlayerStat.SetStat(statInfo.stat, statInfo.value);
        });
    }

    /// <summary>
    /// 제거 이펙트
    /// </summary>
    /// <param name="artifact"></param>
    private void OnArtifactUnequip(Artifact artifact) 
    {
        artifact.MountingEffect.ForEach(statInfo => {
            player.PlayerStat.SetStat(statInfo.stat, -statInfo.value);
        });
    }
}
