using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
public class CreateEnemySO : IDataLoadProcess
{
    public void Process(string[] dataArray)
    {
        //¿Ã∏ß hp speed critical
        EnemyInfoSO asset = AssetDatabase.LoadAssetAtPath<EnemyInfoSO>($"Assets/01.Scripts/Character/SO/{dataArray[0]}.asset");

        if (asset == null)
        {
            asset = ScriptableObject.CreateInstance<EnemyInfoSO>();
            string fileNname = AssetDatabase.GenerateUniqueAssetPath($"Assets/06. SO/Enemy/Info/{dataArray[0]}.asset");
            AssetDatabase.CreateAsset(asset, fileNname);
        }

        asset.maxHealth = int.Parse(dataArray[1]);
        asset.killReward = int.Parse(dataArray[2]);
        asset.meleeAttackRangeRadius = float.Parse(dataArray[3]);
        asset.meleeAttackPower = int.Parse(dataArray[4]);
        asset.rangeAttackPower = int.Parse(dataArray[5]);
        asset.attackDistance = float.Parse(dataArray[6]);
        asset.attackTime = float.Parse(dataArray[7]);
        asset.attackDelayTime = float.Parse(dataArray[8]);

        AssetDatabase.SaveAssets();
    }
}
#endif