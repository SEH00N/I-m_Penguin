using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainSceneUI : MonoBehaviour
{
    private UIDocument document;
    private VisualElement root;
    private VisualElement activePanel;
    private VisualElement introPanel;
    private VisualElement settingPanel;

    private void Awake()
    {
        document = GetComponent<UIDocument>();
    }

    private void OnEnable()
    {
        root = document.rootVisualElement;
        introPanel = root.Q<VisualElement>("IntroPanel");
        settingPanel = root.Q<VisualElement>("SettingPanel");

        activePanel = introPanel;

        SetEvent();
    }

    private void SetEvent()
    {
        root.Q<Button>("SettingBtn").RegisterCallback<ClickEvent>(e =>
        {
            SetActivePanel(settingPanel);
        });

        root.Q<Button>("QuitBtn").RegisterCallback<ClickEvent>(e =>
        {
            Debug.Log("quit");
            Application.Quit();
        });
    }

    private void SetActivePanel(VisualElement panel)
    {
        activePanel.AddToClassList("off");
        activePanel = panel;
        activePanel.RemoveFromClassList("off");
    }
}
