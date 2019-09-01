using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConfigurationUtils {

    #region Fields

    static ConfigurationData configurationData;

    #endregion

    #region Properties

    #region Properties for "Experience to reach level"
    /// <summary>
    /// Gets the number of experience to reach level two
    /// </summary>
    public static int ExpToReachLevelTwo {
        get { return configurationData.ExpToReachLevelTwo; }
    }

    #endregion

    #endregion

    #region Methods
    /// <summary>
    /// Initialize configuration data by creating a new ConfigurationData
    /// </summary>
    public static void Initialize() {

        configurationData = new ConfigurationData();
    }

    #endregion
}
