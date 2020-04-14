using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UIElements.Button;
using PopupWindow = UnityEngine.UIElements.PopupWindow;

/// <summary>
/// Dialogue graph view class
/// </summary>
public class DialogueGraphView : GraphView {

    #region Fields

    public readonly Vector2 defaultNodeSize = new Vector2(x: 150, y: 200);

    #endregion

    #region Public Methods

    /// <summary>
    /// Graph view constructor
    /// </summary>
    public DialogueGraphView() {

        SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);
 
            this.AddManipulator(new ContentDragger());
            this.AddManipulator(new SelectionDragger());
            this.AddManipulator(new RectangleSelector());
            this.AddManipulator(new FreehandSelector());

        // create custom background
        var background = new GridBackground();
        Insert(index: 0, background);
        background.StretchToParentSize();

        // add entry node to graph view
        AddElement(GenerateEntryPointNode());
        }

    /// <summary>
    /// Override to return all ports to making port connection possible
    /// </summary>
    /// <param name="startPort"></param>
    /// <param name="nodeAdapter"></param>
    /// <returns></returns>
    public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter) {

        var compatiblePorts = new List<Port>();

        ports.ForEach(funcCall: (port) => {

            if (startPort != port && startPort.node != port.node) {
                compatiblePorts.Add(port);
            }
        });
        return compatiblePorts;

    }

    /// <summary>
    /// Add new node to the Graph
    /// </summary>
    public void CreateNode(string nodeName) {

        AddElement(CreateDialogueNode(nodeName));

    }
    /// <summary>
    /// Create dialogue node
    /// </summary>
    /// <param name="nodeName"></param>
    /// <returns></returns>
    public DialogueNode CreateDialogueNode(string nodeName) {

        var dialogueNode = new DialogueNode {

            title = nodeName,
            GUID = Guid.NewGuid().ToString(),
            DialogueText = nodeName
        };
        var inputPort = GeneratePort(dialogueNode, Direction.Input, Port.Capacity.Multi);
        inputPort.portName = "Input";
        dialogueNode.inputContainer.Add(inputPort);

        // add CSS style to node
        dialogueNode.styleSheets.Add(Resources.Load<StyleSheet>("Node"));
        

        // add choice button to node
        var button = new Button(clickEvent: () => { AddChoicePort(dialogueNode); });
        button.text = "New Choice";
        dialogueNode.titleContainer.Add(button);

        // Dialogue text field
        var textField = new TextField(string.Empty);
        textField.styleSheets.Add(Resources.Load<StyleSheet>("DialogueTextField"));

        textField.multiline = true;
        textField.RegisterValueChangedCallback(evt => {

            dialogueNode.DialogueText = evt.newValue;
            if(textField.value.Count() <= 20)
            dialogueNode.title = evt.newValue;
        });

        textField.SetValueWithoutNotify(dialogueNode.title);
        dialogueNode.mainContainer.Add(textField);

        // refresh port
        dialogueNode.RefreshExpandedState();
        dialogueNode.RefreshPorts();
        dialogueNode.SetPosition(new Rect(position: Vector2.zero, defaultNodeSize));
        return dialogueNode;
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Generate port
    /// </summary>
    /// <param name="node"></param>
    /// <param name="portDirection"></param>
    /// <param name="capacity"></param>
    /// <returns></returns>
    private Port GeneratePort(DialogueNode node, Direction portDirection, Port.Capacity capacity = Port.Capacity.Single) {
        return node.InstantiatePort(Orientation.Horizontal, portDirection, capacity, typeof(float));
    }

    /// <summary>
    /// Generate entry node rect
    /// </summary>
    /// <returns></returns>
    private DialogueNode GenerateEntryPointNode() {

        // Create start node instance
        var node = new DialogueNode() {

            name = "entire",
            title = "START",
            GUID = GUID.Generate().ToString(),
            DialogueText = "ENTRYPOINT",
            EntryPoint = true

        };
        node.styleSheets.Add(Resources.Load<StyleSheet>("EntireNode"));
        // generate port, name it and add to the node
        var generatedPort = GeneratePort(node, Direction.Output);
        generatedPort.portName = "Next";
        node.outputContainer.Add(generatedPort);

        // refresh port
        node.RefreshExpandedState();
        node.RefreshPorts();

        // draw node
        node.SetPosition(new Rect(x: 100, y: 200, width: 100, height: 150));
        return node;
    }

    /// <summary>
    /// Add new choice port
    /// </summary>
    /// <param name="dialogueNode"></param>
    public void AddChoicePort(DialogueNode dialogueNode, string overridenPortName = "") {

        var generatedPort = GeneratePort(dialogueNode, Direction.Output);
        generatedPort.name = "port";

        var oldLabel = generatedPort.contentContainer.Q<Label>(name: "type");
        generatedPort.contentContainer.Remove(oldLabel);

        /// name new ports in query order
        var outputPortCount = dialogueNode.outputContainer.Query(name: "connector").ToList().Count;

        var choicePortName = string.IsNullOrEmpty(overridenPortName) ?
            $"Choice {outputPortCount + 1}" : overridenPortName;

        var textField = new TextField() {

            name = "choice",
            value = choicePortName
        };
        
        textField.styleSheets.Add(Resources.Load<StyleSheet>("ChoiceField"));

        textField.RegisterValueChangedCallback(evt => generatedPort.portName = evt.newValue);
        generatedPort.contentContainer.Add(new Label(" "));
        generatedPort.contentContainer.Add(textField);

        var deleteButton = new Button(() => RemovePort(dialogueNode, generatedPort)) {

            text = "X"
        };

        generatedPort.contentContainer.Add(deleteButton);

        generatedPort.portName = choicePortName;
        dialogueNode.outputContainer.Add(generatedPort);
        dialogueNode.RefreshPorts();
        dialogueNode.RefreshExpandedState();
    }

    private void RemovePort(DialogueNode dialogueNode, Port generatedPort) {

        var targetEdge = edges.ToList().Where(x => x.output.portName == generatedPort.portName &&
        x.output.node == generatedPort.node);

        if(targetEdge.Any()) {

            var edge = targetEdge.First();
            edge.input.Disconnect(edge);
            RemoveElement(targetEdge.First());
        }

        dialogueNode.outputContainer.Remove(generatedPort);
        dialogueNode.RefreshPorts();
        dialogueNode.RefreshExpandedState();
    }
    #endregion
}