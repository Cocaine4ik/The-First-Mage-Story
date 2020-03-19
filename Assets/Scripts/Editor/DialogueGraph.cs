using UnityEditor;
using UnityEngine;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

public class DialogueGraph : EditorWindow
{
    private DialogueGraphView graphView;


    [MenuItem("Graph/Dialogue Graph")]
    public static void OpenDialogueGraphWindow() {

        var window = GetWindow<DialogueGraph>();
        window.titleContent = new GUIContent(text: "Dialogue Graph");
    }

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

        // Create and add node cretion button to our toolbar
        var nodeCreationButton = new Button(clickEvent: () => graphView.CreateNode("Dialogue Node"));
        nodeCreationButton.text = "Create node";
        toolbar.Add(nodeCreationButton);

        rootVisualElement.Add(toolbar);
    }
    private void OnDisable() {
        
    }
}
