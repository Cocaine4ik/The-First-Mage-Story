using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusUtils
{
    #region Fields

    private static bool gUIisActive = true;
    #endregion

    #region Properties

    public static bool IsPause { get; set; }
    public static bool MusicOn { get; set; }
    public static bool GUIisActive { get; set; }

    #endregion
}
