using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UIElements.Button;

/// <summary>
/// Dialogue graph view class
/// </summary>
public class DialogueGraphView : GraphView {

    #region Fields

    private readonly Vector2 defaultNodeSize = new Vector2(x: 150, y: 200);

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

        };

        var inputPort = GeneratePort(dialogueNode, Direction.Input, Port.Capacity.Multi);
        inputPort.portName = "Input";
        dialogueNode.inputContainer.Add(inputPort);

        // add choice button to node
        var button = new Button(clickEvent: () => { AddChoicePort(dialogueNode); });
        button.text = "New Choice";
        dialogueNode.titleContainer.Add(button);

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

            title = "START",
            GUID = GUID.Generate().ToString(),
            DialgueText = "ENTRYPOINT",
            EntryPoint = true

        };
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
    public void AddChoicePort(DialogueNode dialogueNode, string overridenPortName = "" ) {

        var generatedPort = GeneratePort(dialogueNode, Direction.Output);

        /// name new ports in query order
        var outputPortCount = dialogueNode.outputContainer.Query(name: "connector").ToList().Count;
        generatedPort.portName = $"Choice {outputPortCount}";

        dialogueNode.outputContainer.Add(generatedPort);
        dialogueNode.RefreshPorts();
        dialogueNode.RefreshExpandedState();
    }
    #endregion
}