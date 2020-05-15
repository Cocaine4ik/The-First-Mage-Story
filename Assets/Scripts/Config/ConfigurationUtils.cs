using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConfigurationUtils {

    #region Fields

    static ConfigurationData configurationData;

    #endregion

    #region Properties

    #region Experience to reach level

    /// <summary>
    /// Gets the number of experience to reach level two
    /// </summary>
    public static int ExpToReachLevelTwo {
        get { return configurationData.ExpToReachLevelTwo; }
    }
    
    /// <summary>
    /// Gets the number of experience to reach level three
    /// </summary>
    public static int ExpToReachLevelThree {
        get { return configurationData.ExpToReachLevelThree; }
    }
    /*
    /// <summary>
    /// Gets the number of experience to reach level four
    /// </summary>
    public static int ExpToReachLevelFour {
        get { return configurationData.ExpToReachLevelFour; }
    }
    */
    #endregion

    #region Attributes default

    public static int KnowledgeDefault => configurationData.KnowledgeDefault;
    public static int WisdomDefault => configurationData.WisdomDefault;
    public static int SpiritDefault => configurationData.SpiritDefault;
    public static int FaithDefault => configurationData.FaithDefault;
    public static int DemonsDefault => configurationData.DemonsDefault;
    public static int AlchemyDefault => configurationData.AlchemyDefault;
    public static int HealthBySpiritPoint => configurationData.HealthBySpiritPoint;
    public static int ManaByWisdomPoint => configurationData.ManaByWisdomPoint;

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
