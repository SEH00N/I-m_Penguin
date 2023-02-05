using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;
using System.Threading.Tasks;
using UnityEditor;

#if UNITY_EDITOR
public class DataLoad
{
    private IDataLoadProcess dataLoadProcess;

    public DataLoad(string documentID, string sheetID, IDataLoadProcess _dataLoadProcess)
    {
        dataLoadProcess = _dataLoadProcess;

        GetDate(documentID, sheetID);
    }

    private async void GetDate(string documentID, string sheetID)
    {
        string url = $"https://docs.google.com/spreadsheets/d/{documentID}/export?format=tsv&gid={sheetID}";

        UnityWebRequest request = UnityWebRequest.Get(url);

        var requestTask = Task.Run(() => request.SendWebRequest());
        await requestTask;

        if (request.result == UnityWebRequest.Result.ConnectionError || request.responseCode != 200)
        {
            Debug.Log("error");

            return;
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