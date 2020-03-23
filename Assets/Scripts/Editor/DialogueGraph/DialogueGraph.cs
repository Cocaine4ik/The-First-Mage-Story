using UnityEditor;
using UnityEngine;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using System;

/// <summary>
/// Dialogue graph class
/// </summary>
public class DialogueGraph : EditorWindow
{
    #region Fields

    private DialogueGraphView graphView;
    private string fileName = "Dialogue Graph";

    #endregion

    #region Public Methods

    /// <summary>
    /// Create menu tab for Dialogue graph
    /// </summary>
    [MenuItem("Graph/Dialogue Graph")]
    public static void OpenDialogueGraphWindow() {

        var window = GetWindow<DialogueGraph>();
        window.titleContent = new GUIContent(text: "Dialogue Graph");
    }

    #endregion

    #region Private Metods

    private void OnEnable() {

        ConstructGraphView();
        GenerateToolbar();
    }

    /// <summary>
    /// Construct graph view board
    /// </summary>
    private void ConstructGraphView() {

        graphView = new DialogueGraphView {

            name = "Dialogue Graph",

        };
        graphView.StretchToParentSize();
        rootVisualElement.Add(graphView);

    }

    /// <summary>
    /// Generate toolbar
    /// </summary>
    private void GenerateToolbar() {

        var toolbar = new Toolbar();

        // New Dialogue + rename
        var fileNameTextField = new TextField(label: "File Name: ");
        fileNameTextField.SetValueWithoutNotify(fileName);
        fileNameTextField.MarkDirtyRepaint();
        fileNameTextField.RegisterValueChangedCallback(evt => fileName = evt.newValue);
        toolbar.Add(fileNameTextField);

        toolbar.Add(new Button(clickEvent: () => SaveData()) { text = "Save Data" });
        toolbar.Add(new Button(clickEvent: () => LoadData()) { text = "Load Data" });

        // Create and add node cretion button to our toolbar
        var nodeCreationButton = new Button(clickEvent: () => graphView.CreateNode("Dialogue Node"));
        nodeCreationButton.text = "Create node";
        toolbar.Add(nodeCreationButton);

        rootVisualElement.Add(toolbar);
    }

    private void LoadData() {
        throw new NotImplementedException();
    }

    private void SaveData() {
        throw new NotImplementedException();
    }

    private void OnDisable() {
        
    }

    #endregion
}
