using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConfigurationUtils {

    #region Fields

    static ConfigurationData configurationData;

    #endregion

    #region Properties

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
