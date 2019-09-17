using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;

public static class SaveSystem {
    /// <summary>
    /// Save Player Data to Player.fun
    /// </summary>
    /// <param name="player"></param>
   public static void SavePlayer(GameObject player)  {

        BinaryFormatter formatter = new BinaryFormatter();

        // C:/Users/Cocaine/AppData/LocalLow/DefaultCompany/The First Mage Story
        string path = Application.persistentDataPath + "/Player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("Save Complete.");
        
    }
    /// <summary>
    /// Load Player Data from Player.fun
    /// </summary>
    /// <returns></returns>
    public static PlayerData LoadPlayer() {

        string path = Application.persistentDataPath + "/Player.fun";
        
        if(File.Exists(path)) {

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
    /// <summary>
    /// Save Level Data to Level.fun
    /// </summary>
    public static void SaveLevel() {

        LevelObject[] levelObjects = GameObject.FindObjectsOfType<LevelObject>();
        List<LevelObject> objects = levelObjects.OfType<LevelObject>().ToList();

        BinaryFormatter formatter = new BinaryFormatter();

        // C:/Users/Cocaine/AppData/LocalLow/DefaultCompany/The First Mage Story
        string path = Application.persistentDataPath + "/Level.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        LevelData data = new LevelData(objects);

        formatter.Serialize(stream, data);
        stream.Close();

    }
    /// <summary>
    /// Load Level Data from Level.fun
    /// </summary>
    /// <returns></returns>
    public static LevelData LoadLevel() {

        string path = Application.persistentDataPath + "/Level.fun";

        if(File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            LevelData data = formatter.Deserialize(stream) as LevelData;
            stream.Close();

            return data;
        }
        else {
            Debug.LogError("Save file not found in " + path);
            return null;
        }

    }

    /// <summary>
    /// Save GUI Data to GUI.fun
    /// </summary>
    /// <param name="gameUserInterfacee"></param>
    public static void SaveGUI(GUI gameUserInterfacee) {

        BinaryFormatter formatter = new BinaryFormatter();

        // C:/Users/Cocaine/AppData/LocalLow/DefaultCompany/The First Mage Story
        string path = Application.persistentDataPath + "/GUI.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        GUIData data = new GUIData(gameUserInterfacee);

        formatter.Serialize(stream, data);
        stream.Close();

    }
    /// <summary>
    /// Load GUI Data from GUI.fun
    /// </summary>
    /// <returns></returns>
    public static GUIData LoadGui() {

        string path = Application.persistentDataPath + "/GUI.fun";

        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GUIData data = formatter.Deserialize(stream) as GUIData;
            stream.Close();

            return data;
        }
        else {
            Debug.LogError("Save file not found in " + path);
            return null;
        }

    }

}
