using System;
using UnityEngine;

[Serializable]
public class DialogueNodeData
{
    #region Fields

    public string nodeGUID;
    public string dialogueText;
    public Vector2 position;

    #endregion

    #region Properties

    public string NodeGUID { get; set; }
    public string DialogueText { get; set; }
    public Vector2 Position { get; set; }

    #endregion
}
