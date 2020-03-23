using UnityEditor.Experimental.GraphView;

/// <summary>
/// Dialogue node class
/// </summary>
public class DialogueNode : Node
{
    #region Fields

    public string gUID;
    public string dialgueText;
    public bool entryPoint = false;

    #endregion

    #region Properties

    public string GUID { get; set; }
    public string DialgueText { get; set; }
    public bool EntryPoint { get; set; }

    #endregion
}
