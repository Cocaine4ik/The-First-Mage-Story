using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData {

    #region Fields

    private List<LevelObject> objects;


    #endregion
    /// <summary>
    /// Save all left level objects data
    /// </summary>
    /// <param name="objects"></param>
    public LevelData(List<LevelObject> objects) {

        this.objects = objects;
    }
}
