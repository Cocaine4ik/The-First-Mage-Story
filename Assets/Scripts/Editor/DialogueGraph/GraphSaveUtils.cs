using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
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
                DialogueText = dialogueNode.DialgueText,
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

        //ClearGraph();
       // CreateNodes();
       // ConnectNodes();
    }

    private void ClearGraph() {
       // Nodes.Find()
    }

    #endregion
}
