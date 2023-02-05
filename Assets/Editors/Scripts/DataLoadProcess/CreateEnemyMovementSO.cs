using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
public class CreateEnemyMovementSO : IDataLoadProcess
{
    public void Process(string[] dataArray)
    {
        MovementSO asset = AssetDatabase.LoadAssetAtPath<MovementSO>($"Assets/06. SO/Enemy/Movement/{dataArray[0]}.asset");

        if (asset == null)
        {
            asset = ScriptableObject.CreateInstance<MovementSO>();
            string fileNname = AssetDatabase.GenerateUniqueAssetPath($"Assets/06. SO/Enemy/Movement/{dataArray[0]}.asset");
            AssetDatabase.CreateAsset(asset, fileNname);
        }

        asset.inAccel = float.Parse(dataArray[1]);
        asset.deAccel = float.Parse(dataArray[2]);
        asset.maxSpeed = float.Parse(dataArray[3]);

        AssetDatabase.SaveAssets();
    }
}
#endif
