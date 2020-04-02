using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using UnityEngine;

/// <summary>
/// Graph save unility
/// </summary>
public class GraphSaveUtils
{
    #region Fields

    private DialogueGraphView dialogueGraphView;
    private DialogueContainer dialogueContainer;

    #endregion

    #region Properties

    private List<Edge> Edges => dialogueGraphView.edges.ToList();
    private List<DialogueNode> Nodes => dialogueGraphView.nodes.ToList().Cast<DialogueNode>().ToList();

    #endregion

    #region Methods

    public static GraphSaveUtils GetInstance(DialogueGraphView targetGraphView) {

        return new GraphSaveUtils {

            dialogueGraphView = targetGraphView
        };
    }

    public void SaveGraph(string fileName) {

         // if there are no edges (no connctions) then return

        var dialogueContainer = ScriptableObject.CreateInstance<DialogueContainer>();
        if (!SaveNodes(fileName, dialogueContainer)) return;

        var dialogueLanguge = fileName.Substring(fileName.Count() - 2);
        AssetDatabase.CreateAsset(dialogueContainer, $"Assets/Resources/Dialogues/{dialogueLanguge}/{fileName}.asset");
        AssetDatabase.SaveAssets();
    }
    /// <summary>
    /// Save nodes
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="dialogueContainer"></param>
    /// <returns></returns>
    private bool SaveNodes(string fileName, DialogueContainer dialogueContainer) {

        if (!Edges.Any()) return false;
        var connectedPorts = Edges.Where(x => x.input.node != null).ToArray();

        for (int i = 0; i < connectedPorts.Count(); i++) {

            var outputNode = connectedPorts[i].output.node as DialogueNode;
            var inputNode = connectedPorts[i].input.node as DialogueNode;

            dialogueContainer.NodeLinks.Add(new NodeLinkData {

                BaseNodeGUID = outputNode.GUID,
                PortName = connectedPorts[i].output.portName,
                TargetNodeGUID = inputNode.GUID
            });
        }

        foreach (var dialogueNode in Nodes.Where(node => !node.EntryPoint)) {

            dialogueContainer.DialogueNodeData.Add(new DialogueNodeData {

                NodeGUID = dialogueNode.GUID,
                DialogueText = dialogueNode.DialogueText,
                Position = dialogueNode.GetPosition().position

            });
        }
        return true;
    }
    public void LoadGraph(string fileName ) {

        var dialogueLanguge = fileName.Substring(fileName.Count() - 2);
        dialogueContainer = Resources.Load<DialogueContainer>($"Dialogues/{dialogueLanguge}/{fileName}");
        if (dialogueContainer == null) {

            EditorUtility.DisplayDialog("File Not Found", "Target dialogue graph file does not exists", "OK");
            return;
        }

        ClearGraph();
        CreateNodes();
        ConnectNodes();
    }

    private void ConnectNodes() {
        
        for (int i = 0; i < Nodes.Count; i++) {

            var connections = dialogueContainer.NodeLinks.Where(x => x.BaseNodeGUID == Nodes[i].GUID).ToList();

            for (int k = 0; k < connections.Count; k++ ) {

                var targetNodeGild = connections[k].TargetNodeGUID;
                var targetNode = Nodes.First(x => x.GUID == targetNodeGild);

                LinkNodes(Nodes[i].outputContainer[k].Q<Port>(), (Port)targetNode.inputContainer[0]);

                targetNode.SetPosition(new Rect(dialogueContainer.DialogueNodeData.First(
                    x => x.NodeGUID == targetNodeGild).Position, dialogueGraphView.defaultNodeSize));
            }
        }

    }

    private void LinkNodes(Port outputPort, Port inputPort) {

        var tempEdge = new Edge {
            output = outputPort,
            input = inputPort
        };

        tempEdge.input.Connect(tempEdge);
        tempEdge.output.Connect(tempEdge);

        dialogueGraphView.Add(tempEdge);
    }

    private void CreateNodes() {

        foreach (var nodeData in dialogueContainer.DialogueNodeData) {

            var tempNode = dialogueGraphView.CreateDialogueNode(nodeData.DialogueText);
            tempNode.GUID = nodeData.NodeGUID;
            dialogueGraphView.AddElement(tempNode);

            var nodePorts = dialogueContainer.NodeLinks.Where(x => x.BaseNodeGUID == nodeData.NodeGUID).ToList();
            nodePorts.ForEach(x => dialogueGraphView.AddChoicePort(tempNode, x.PortName));
        }
    }

    private void ClearGraph() {

        // Set entry points guid back form the save. Discards existing grid
        Nodes.Find(match: x => x.EntryPoint).GUID = dialogueContainer.NodeLinks[0].BaseNodeGUID;

        foreach(var node in Nodes) {

            if (node.EntryPoint) continue;

            // Remove edges that conected to this node
            Edges.Where(x => x.input.node == node).ToList().ForEach(edge => 
            dialogueGraphView.RemoveElement(edge));

            // Then remove the node
            dialogueGraphView.RemoveElement(node);
        }
    }

    #endregion
}
