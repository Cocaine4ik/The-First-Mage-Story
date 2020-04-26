using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusUtils
{
    #region Fields

    private static bool gUIisActive = false;
    private static bool dialogueIsActive = false;
    #endregion

    #region Properties

    public static bool IsPause { get; set; }
    public static bool MusicOn { get; set; }

    public static bool GUIisActive {
        get { return gUIisActive; }
        set { gUIisActive = value; }
    }

    public static bool DialogueIsActive {
        get { return dialogueIsActive; }
        set { dialogueIsActive = value; }
    }
    #endregion
}
