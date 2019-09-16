using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;

public static class SaveSystem {

   public static void SavePlayer(GameObject player) {

        BinaryFormatter formatter = new BinaryFormatter();

        // C:/Users/Cocaine/AppData/LocalLow/DefaultCompany/The First Mage Story
        string path = Application.persistentDataPath + "/Player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("Save Complete.");
        
    }

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

    public static void SaveLevel() {

        LevelObject[] levelObjects = GameObject.FindObjectsOfType<LevelObject>();
        List<LevelObject> objects = levelObjects.OfType<LevelObject>().ToList();

        BinaryFormatter formatter = new BinaryFormatter();

        // C:/Users/Cocaine/AppData/LocalLow/DefaultCompany/The First Mage Story
        string path = Application.persistentDataPath + "Level.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        LevelData data = new LevelData(objects);

        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static LevelData LoadLevel() {

        string path = Application.persistentDataPath + "Level.fun";

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
}
