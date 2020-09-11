using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusUtils
{
    #region Fields

    private static bool gUIisActive = false;
    private static bool dialogueIsActive = false;
    private static bool cutScenePlaying = false;
    private static bool isLoad = false;
    #endregion

    #region Properties

    public static bool IsPause { get; set; }
    public static bool MusicOn { get; set; }

    public static bool GUIisActive { get => gUIisActive; set => gUIisActive = value; }
    public static bool CutScenePlaying { get => cutScenePlaying; set => cutScenePlaying = value;}
    public static bool DialogueIsActive { get => dialogueIsActive; set => dialogueIsActive = value; }
    public static bool IsLoad { get => isLoad; set => isLoad = value; }

    #endregion
}
