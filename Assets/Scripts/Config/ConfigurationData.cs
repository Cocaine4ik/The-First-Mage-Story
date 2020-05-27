using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text.RegularExpressions;
using System;

// Provides acess to configurtion data
public class ConfigurationData{

    private Dictionary<ConfigurationDataValueName, float> values = new Dictionary<ConfigurationDataValueName, float>();


    #region Propeties

    #region Experience to Level Up

    public int ExpToLevelTwo => (int)values[ConfigurationDataValueName.ExpToToLeveLTwo];
    public int ExpToLevelThree => (int)values[ConfigurationDataValueName.ExpToToLevelThree];
    public int ExpToLevelFour => (int)values[ConfigurationDataValueName.ExpToToLevelFour];
    public int ExpToLevelFive => (int)values[ConfigurationDataValueName.ExpToToLevelFive];
    public int ExpToLevelSix => (int)values[ConfigurationDataValueName.ExpToToLevelSix];
    public int ExpToLevelSeven => (int)values[ConfigurationDataValueName.ExpToToLevelSeven];
    public int ExpToLevelEight => (int)values[ConfigurationDataValueName.ExpToToLevelEight];
    public int ExpToLevelNine => (int)values[ConfigurationDataValueName.ExpToToLevelNine];
    public int ExpToLevelTen => (int)values[ConfigurationDataValueName.ExpToToLevelTen];
    public int ExpToLevelEleven => (int)values[ConfigurationDataValueName.ExpToToLevelEleven];
    public int ExpToLevelTwelve => (int)values[ConfigurationDataValueName.ExpToToLevelTwelve];
    public int ExpToLevelThirteen => (int)values[ConfigurationDataValueName.ExpToToLevelThirteen];
    public int ExpToLevelFourteen => (int)values[ConfigurationDataValueName.ExpToToLevelFourteen];
    public int ExpToLevelFifteen => (int)values[ConfigurationDataValueName.ExpToToLevelFifteen];
    public int ExpToLevelSixteen => (int)values[ConfigurationDataValueName.ExpToToLevelSixteen];
    public int ExpToLevelSeventeen => (int)values[ConfigurationDataValueName.ExpToToLevelSeventeen];
    public int ExpToLevelEighteen => (int)values[ConfigurationDataValueName.ExpToToLevelEighteen];
    public int ExpToLevelNineteen => (int)values[ConfigurationDataValueName.ExpToToLevelNineteen];
    public int ExpToLevelTwenty => (int)values[ConfigurationDataValueName.ExpToToLevelTwenty];

    #endregion

    public int SkillPointsPerLevel => (int)values[ConfigurationDataValueName.SkillPointsPerLevel];
    public int HealthBySpiritPoint => (int)values[ConfigurationDataValueName.HealthBySpiritPoint];
    public int ManaByWisdomPoint => (int)values[ConfigurationDataValueName.ManaByWisdomPoint];
    public int FaithChanceModifier => (int)values[ConfigurationDataValueName.FaithChanceModifier];

    #region Attributes default

    public int KnowledgeDefault => (int)values[ConfigurationDataValueName.KnowledgeDefault];
    public int WisdomDefault => (int)values[ConfigurationDataValueName.WisdomDefault];
    public int SpiritDefault => (int)values[ConfigurationDataValueName.SpiritDefault];
    public int FaithDefault => (int)values[ConfigurationDataValueName.FaithDefault];
    public int DemonsDefault => (int)values[ConfigurationDataValueName.DemonsDefault];
    public int AlchemyDefault => (int)values[ConfigurationDataValueName.AlchemyDefault];

    #endregion

    #endregion

    #region Constructor

    public ConfigurationData() {
        Read();
    }
    #endregion

    #region Methods

    /// <summary>
    /// Read ConfigurationData spreadsheets.
    /// </summary>
    private void Read(string path = "Data/Config") {

        // if dictinory includes value return dictionary
        if (values.Count > 0) return;
        var textAssets = Resources.LoadAll<TextAsset>(path);

        foreach (var textAsset in textAssets) {

            var text = ReplaceMarkers(textAsset.text);
            var matches = Regex.Matches(text, "\"[\\s\\S]+?\"");
            
            foreach (Match match in matches) {
                text = text.Replace(match.Value, match.Value.Replace("\"", null).Replace(",", "[comma]").Replace("\n", "[newline]"));
            }

            var lines = text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            
            for (var i = 1; i < lines.Length; i++) {

                var columns = lines[i].Split(',').Select(j => j.Trim()).Select(j => j.Replace("[comma]", ",").Replace("[newline]", "\n")).ToList();
                var valueName = (ConfigurationDataValueName)Enum.Parse(typeof(ConfigurationDataValueName), columns[0]);
                var value = float.Parse(columns[1]);

                values.Add(valueName, value);

            }
        }
    }

    private string ReplaceMarkers(string text) {
        return text.Replace("[Newline]", "\n");
    }

    #endregion
}
