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
    private DialogueContainer containerCache;

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

        if (!Edges.Any()) return; // if there are no edges (no connctions) then return

        var dialogueContainer = ScriptableObject.CreateInstance<DialogueContainer>();
        var connectedPorts = Edges.Where(x => x.input.node != null).ToArray();

        for (int i = 0; i < connectedPorts.Length; i++) {

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

        AssetDatabase.CreateAsset(dialogueContainer, $"Assets/Resources/Dialogues/{fileName}.asset");
        AssetDatabase.SaveAssets();
    }

    public void LoadGraph(string fileName ) {

        containerCache = Resources.Load<DialogueContainer>($"Dialogues/{fileName}");
        if (containerCache == null) {

            EditorUtility.DisplayDialog("File Not Found", "Target dialogue graph file does not exists", "OK");
            return;
        }

        ClearGraph();
        CreateNodes();
        //ConnectNodes();
    }

    private void ConnectNodes() {
        
        for (int i = 0; i < Nodes.Count; i++) {

            var connections = containerCache.NodeLinks.Where(x => x.BaseNodeGUID == Nodes[i].GUID).ToList();

            for (int k = 0; k < connections.Count; k++ ) {

                var targetNodeGild = connections[k].TargetNodeGUID;
                var targetNode = Nodes.First(x => x.GUID == targetNodeGild);

                LinkNodes(Nodes[i].outputContainer[k].Q<Port>(), (Port)targetNode.inputContainer[0]);

                targetNode.SetPosition(new Rect(containerCache.DialogueNodeData.First(
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

        foreach (var nodeData in containerCache.DialogueNodeData) {

            var tempNode = dialogueGraphView.CreateDialogueNode(nodeData.DialogueText);
            tempNode.GUID = nodeData.NodeGUID;
            dialogueGraphView.AddElement(tempNode);

            var nodePorts = containerCache.NodeLinks.Where(x => x.BaseNodeGUID == nodeData.NodeGUID).ToList();
            nodePorts.ForEach(x => dialogueGraphView.AddChoicePort(tempNode, x.PortName));
        }
    }

    private void ClearGraph() {

        // Set entry points guid back form the save. Discards existing grid
        Nodes.Find(match: x => x.EntryPoint).GUID = containerCache.NodeLinks[0].BaseNodeGUID;

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
