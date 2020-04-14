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

        toolbar.style.height = 40;

        // New Dialogue + rename
        var fileNameTextField = new TextField(label: "File Name: ");
        fileNameTextField.labelElement.style.color = Color.black;
        fileNameTextField.SetValueWithoutNotify(fileName);
        fileNameTextField.MarkDirtyRepaint();
        fileNameTextField.RegisterValueChangedCallback(evt => fileName = evt.newValue);
        fileNameTextField.style.alignSelf = Align.Center;
        fileNameTextField.labelElement.style.minWidth = 40;
        fileNameTextField.labelElement.style.marginLeft = 20;

        fileNameTextField.styleSheets.Add(Resources.Load<StyleSheet>("FileNameTextField"));

        // Create and add node cretion button to our toolbar
        var createNodeButton = CreateButton(clickEvent: () => graphView.CreateNode("Dialogue Node"), "Create \n Node");
        createNodeButton.style.marginRight = 40;
        toolbar.Add(createNodeButton);

        // add save button with click event if requestDataOperation - save operation - save data
        toolbar.Add(CreateButton(clickEvent: () => RequestDataOperation(save: true), "Save \n Data"));
        // add save button with click event if requestDataOperation - not save operation - load data
        toolbar.Add(CreateButton(clickEvent: () => RequestDataOperation(save: false),"Load \n Data" ));

        toolbar.Add(fileNameTextField);


        rootVisualElement.Add(toolbar);
    }

    /// <summary>
    /// Create button with custom style template
    /// </summary>
    /// <param name="clickEvent"></param>
    /// <param name="text"></param>
    /// <returns></returns>
    private Button CreateButton(Action clickEvent, string text) {

        var button = new Button(clickEvent) {
            text = text
        };

        button.style.marginLeft = 1;
        button.style.marginRight = 1;
        button.style.marginTop = 1;
        button.style.marginBottom = 1;

        button.style.width = 40;

        return button;
    }
    private void RequestDataOperation(bool save) {

        if (!string.IsNullOrEmpty(fileName)) {

            var saveUtility = GraphSaveUtils.GetInstance(graphView);
            if (save) {
                saveUtility.SaveGraph(fileName);
            }
            else {
                saveUtility.LoadGraph(fileName);
                
            }
        }
        else {
            EditorUtility.DisplayDialog("Invaliad file name!", "Please enter a valid file name.", "OK");
        }                  
    }

    private void OnDisable() {
        
    }

    #endregion
}
