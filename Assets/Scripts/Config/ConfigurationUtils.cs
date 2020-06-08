using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConfigurationUtils {

    #region Fields

    static ConfigurationData configurationData;

    #endregion

    #region Properties

    #region Experience to reach level

    public static int ExpToLevelTwo => configurationData.ExpToLevelTwo;
    public static int ExpToLevelThree => configurationData.ExpToLevelThree;
    public static int ExpToLevelFour => configurationData.ExpToLevelFour;
    public static int ExpToLevelFive => configurationData.ExpToLevelFive;
    public static int ExpToLevelSix => configurationData.ExpToLevelSix;
    public static int ExpToLevelSeven => configurationData.ExpToLevelSeven;
    public static int ExpToLevelEight => configurationData.ExpToLevelEight;
    public static int ExpToLevelNine => configurationData.ExpToLevelNine;
    public static int ExpToLevelTen => configurationData.ExpToLevelTen;
    public static int ExpToLevelEleven => configurationData.ExpToLevelEleven;
    public static int ExpToLevelTwelve => configurationData.ExpToLevelTwelve;
    public static int ExpToLevelThirteen => configurationData.ExpToLevelThirteen;
    public static int ExpToLevelFourteen => configurationData.ExpToLevelFourteen;
    public static int ExpToLevelFifteen => configurationData.ExpToLevelFifteen;
    public static int ExpToLevelSixteen => configurationData.ExpToLevelSixteen;
    public static int ExpToLevelSeventeen => configurationData.ExpToLevelSeventeen;
    public static int ExpToLevelEighteen => configurationData.ExpToLevelEighteen;
    public static int ExpToLevelNineteen => configurationData.ExpToLevelNineteen;
    public static int ExpToLevelTwenty => configurationData.ExpToLevelTwenty;

    #endregion

    public static int SkillPointsPerLevel => configurationData.SkillPointsPerLevel;
    public static int SpellPointsPerLevel => configurationData.SpellPointsPerLevel;
    public static int HealthBySpiritPoint => configurationData.HealthBySpiritPoint;
    public static int ManaByWisdomPoint => configurationData.ManaByWisdomPoint;
    public static int FaithChanceModifier => configurationData.FaithChanceModifier;

    #region Attributes default

    public static int KnowledgeDefault => configurationData.KnowledgeDefault;
    public static int WisdomDefault => configurationData.WisdomDefault;
    public static int SpiritDefault => configurationData.SpiritDefault;
    public static int FaithDefault => configurationData.FaithDefault;
    public static int DemonsDefault => configurationData.DemonsDefault;
    public static int AlchemyDefault => configurationData.AlchemyDefault;
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
