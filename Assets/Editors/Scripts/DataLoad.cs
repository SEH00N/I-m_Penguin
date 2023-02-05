using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;
using System.Threading.Tasks;
using UnityEditor;
using Unity.EditorCoroutines.Editor;

#if UNITY_EDITOR
public class DataLoad
{
    private IDataLoadProcess dataLoadProcess;

    public DataLoad(string documentID, string sheetID, IDataLoadProcess _dataLoadProcess)
    {
        Debug.Log("create");
        dataLoadProcess = _dataLoadProcess;

        EditorCoroutineUtility.StartCoroutine(GetDate(documentID, sheetID), this);
    }

    private IEnumerator GetDate(string documentID, string sheetID)
    {
        string url = $"https://docs.google.com/spreadsheets/d/{documentID}/export?format=tsv&gid={sheetID}";

        UnityWebRequest request = UnityWebRequest.Get(url);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.responseCode != 200)
        {
            Debug.Log("error");

            yield break;
        }

        HandleData(request.downloadHandler.text);

        Debug.Log("success");
    }

    private void HandleData(string data)
    {
        string[] lines = data.Split("\n");

        for(int lineNum = 1; lineNum < lines.Length; lineNum++)
        {
            string[] dataArray = lines[lineNum].Split("\t");

            dataLoadProcess.Process(dataArray);
        }

        AssetDatabase.Refresh();
    }
}
#endif