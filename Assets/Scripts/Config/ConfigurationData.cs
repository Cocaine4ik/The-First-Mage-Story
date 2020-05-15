﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

// Provides acess to configurtion data
public class ConfigurationData{

    const string ConfigurationDataFileName = "ConfigurationData.csv";
    Dictionary<ConfigurationDataValueName, float> values = new Dictionary<ConfigurationDataValueName, float>();


    #region Propeties

    #region Experience to reach level

    /// <summary>
    /// Gets the number of experience to reach level two
    /// </summary>
    public int ExpToReachLevelTwo {

        get { return (int)values[ConfigurationDataValueName.ExpToReachLeveTwo]; }

    }
    
    /// <summary>
    /// 
    /// </summary>
    public int ExpToReachLevelThree {

        get { return (int)values[ConfigurationDataValueName.ExpToReachLevelThree]; }

    }


    /*
    /// <summary>
    /// Gets the number of experience to reach level four
    /// </summary>
    public int ExpToReachLevelFour {

        get { return (int)values[ConfigurationDataValueName.ExpToReachLevelFour]; }

    }
    */
    #endregion

    #region Attributes default

    public int KnowledgeDefault => (int)values[ConfigurationDataValueName.KnowledgeDefault];
    public int WisdomDefault => (int)values[ConfigurationDataValueName.WisdomDefault];
    public int SpiritDefault => (int)values[ConfigurationDataValueName.SpiritDefault];
    public int FaithDefault => (int)values[ConfigurationDataValueName.FaithDefault];
    public int DemonsDefault => (int)values[ConfigurationDataValueName.DemonsDefault];
    public int AlchemyDefault => (int)values[ConfigurationDataValueName.AlchemyDefault];
    public int HealthBySpiritPoint => (int)values[ConfigurationDataValueName.HealthBySpiritPoint];
    public int ManaByWisdomPoint => (int)values[ConfigurationDataValueName.ManaByWisdomPoint];

    #endregion

    #endregion

    #region Constructor

    public ConfigurationData() {

        // read and save configuration data from file
        StreamReader input = null;
        try {

            // create stream reader object
            input = File.OpenText(Path.Combine(Application.streamingAssetsPath, ConfigurationDataFileName));

            // populate values
            string currentLine = input.ReadLine();

            while(currentLine != null) {

                string[] tokens = currentLine.Split(',');
                // parse string to enum
                ConfigurationDataValueName valueName = (ConfigurationDataValueName)Enum.Parse(typeof(ConfigurationDataValueName), tokens[0]);
                values.Add(valueName, float.Parse(tokens[1]));
                currentLine = input.ReadLine();
            }
        }
        catch(Exception e) {

            // set default values if something went wrong
            SetDefaultValues();
            Debug.Log("Setting default values...");
        }
        finally {

            // always close input file
            if (input != null) {

                input.Close();

            }
        }
    }
    #endregion

    #region Methods

    /// <summary>
    /// clear dictionary and set dafult values
    /// </summary>
    void SetDefaultValues() {

        values.Clear();
        /// <summary>
        /// Values for experience need to reach levels
        /// </summary>
        values.Add(ConfigurationDataValueName.ExpToReachLeveTwo, 500);  
        values.Add(ConfigurationDataValueName.ExpToReachLevelThree, 1000);
        /*
        values.Add(ConfigurationDataValueName.ExpToReachLevelFour, 3000);
        values.Add(ConfigurationDataValueName.ExpToReachLevelFive, 5000);
        values.Add(ConfigurationDataValueName.ExpToReachLevelSix, 8000);
        values.Add(ConfigurationDataValueName.ExpToReachLevelSeven, 12000);
        values.Add(ConfigurationDataValueName.ExpToReachLevelEight, 17000);
        values.Add(ConfigurationDataValueName.ExpToReachLevelNine, 23000);
        values.Add(ConfigurationDataValueName.ExpToReachLevelTen, 30000);
        values.Add(ConfigurationDataValueName.ExpToReachLevelEleven, 38000);
        values.Add(ConfigurationDataValueName.ExpToReachLevelTwelve, 47000);
        values.Add(ConfigurationDataValueName.ExpToReachLevelThirteen, 55000);
        values.Add(ConfigurationDataValueName.ExpToReachLevelFourteen, 62000);
        values.Add(ConfigurationDataValueName.ExpToReachLevelFifteen, 70000);
        values.Add(ConfigurationDataValueName.ExpToReachLevelSixteen, 76000);
        values.Add(ConfigurationDataValueName.ExpToReachLevelSeventeen, 82000);
        values.Add(ConfigurationDataValueName.ExpToReachLevelEighteen, 88000);
        values.Add(ConfigurationDataValueName.ExpToReachLevelNineteen, 93000);
        values.Add(ConfigurationDataValueName.ExpToReachLevelTwelve, 100000);
        */
        values.Add(ConfigurationDataValueName.KnowledgeDefault, 10);
        values.Add(ConfigurationDataValueName.WisdomDefault, 10);
        values.Add(ConfigurationDataValueName.SpiritDefault, 10);
        values.Add(ConfigurationDataValueName.FaithDefault, 10);
        values.Add(ConfigurationDataValueName.DemonsDefault, 0);
        values.Add(ConfigurationDataValueName.AlchemyDefault, 0);
        values.Add(ConfigurationDataValueName.HealthBySpiritPoint, 10);
        values.Add(ConfigurationDataValueName.ManaByWisdomPoint, 10);
    }

    #endregion
}
