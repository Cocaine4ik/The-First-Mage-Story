using UnityEditor.Experimental.GraphView;

/// <summary>
/// Dialogue node class
/// </summary>
public class DialogueNode : Node
{
    #region Fields

    private string gUID;
    private string dialgueText;
    private bool entryPoint = false;

    #endregion

    #region Properties

    public string GUID { get; set; }
    public string DialgueText { get; set; }
    public bool EntryPoint { get; set; }

    #endregion
}
