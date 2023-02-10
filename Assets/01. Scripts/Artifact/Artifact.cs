using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour
{
    [SerializeField] List<StatInfo> mountingEffect = new List<StatInfo>();
    public List<StatInfo> MountingEffect => mountingEffect;
    
    [SerializeField] string artifactName = "";
    public string ArtifactName => artifactName;
}
