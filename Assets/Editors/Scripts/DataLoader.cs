using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

public class DataLoader : EditorWindow
{
    [MenuItem("Tools/DataLoader")]
    public static void OpenWindow()
    {
        EditorWindow window = GetWindow<DataLoader>();
        window.titleContent = new GUIContent("Data Loader");
    }

    private void CreateGUI()
    {
        VisualTreeAsset ui = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editors/UI/DataLoader.uxml");
        VisualElement root = ui.Instantiate();

        root.style.flexBasis = new Length(100, LengthUnit.Percent);

        rootVisualElement.Add(root);

        AddEvent(root);
    }

    private void AddEvent(VisualElement root)
    {
        TextField documentID = root.Q<TextField>("DocumentID");
        TextField sheetID = root.Q<TextField>("SheetID");

        root.Q<Button>().RegisterCallback<ClickEvent>(e =>
        {
            LoadData(documentID, sheetID);
        });
    }

    private void LoadData(TextField documentID, TextField sheetID)
    {
        IDataLoadProcess process = GetProcess(documentID.value, sheetID.value);

        new DataLoad(documentID.value, sheetID.value, process);
    }

    private IDataLoadProcess GetProcess(string documentID, string sheetID)
    {
        switch (documentID)
        {
            case "1Ec8o_dlO4tsVLrZ7SI7tCqKy1fOrmXJhUh1mj-fCbbs":
                switch (sheetID)
                {
                    case "0":
                        return new CreateEnemyMovementSO();
                    case "52017734":
                        return new CreateEnemyInfoSO();
                }

                break;

            default:
                Debug.Log("肋给等 林家");
                break;
        }


        return null;
    }
}
