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
        TextField sheetID = root.Q<TextField>("sheetID");

        root.Q<Button>().RegisterCallback<ClickEvent>(e =>
        {
            new DataLoad(documentID.value, sheetID.value, new CreateEnemySO());
        });
    }
}
