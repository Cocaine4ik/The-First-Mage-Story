using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadGameLevel : SaveLoadData
{
    // list of all objects in scene which must be save and can be detroyed
    [SerializeField] private List<GameObject> objectsToSave = new List<GameObject>();
    // list of objects names which was destroyed
    [SerializeField] private List<string> destroyedObjectsNames = new List<string>();

    protected override void OnEnable()
    {
        base.OnEnable();
        EventManager.StartListening(EventName.LoadScene, OnLoadScene);
        EventManager.StartListening(EventName.SaveMe, OnSaveMe);
        EventManager.StartListening(EventName.AddToGameLevelObjectsList, OnAddToGameLevelObjectsList);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        EventManager.StopListening(EventName.LoadScene, OnLoadScene);
        EventManager.StopListening(EventName.SaveMe, OnSaveMe);
        EventManager.StopListening(EventName.AddToGameLevelObjectsList, OnAddToGameLevelObjectsList);
    }
    /// <summary>
    /// Load scene from savegame
    /// </summary>
    /// <param name="arg"></param>
    public void OnLoadScene(EventArg arg) {

        var sceneName = PlayerPrefs.GetString("SceneName");

        objectsToSave.Clear();
        destroyedObjectsNames.Clear();

        Debug.Log("Loading scene: " +  sceneName);
        SceneManager.LoadScene(sceneName);
        StartCoroutine(LoadData());
        Debug.Log("LoadData");
    }

    /// <summary>
    /// Save objects which was destoyed
    /// In load event all destoyed objects will be destroyed
    /// Using list objectsToSave
    /// </summary>
    /// <param name="arg"></param>
    private void OnSaveMe(EventArg arg) {
        var destroyedObjectName = arg.FirstStringArg;
        destroyedObjectsNames.Add(destroyedObjectName);
    }
    /// <summary>
    /// Load scene after 2 sec waiting (when all scripts and objects are initialized
    /// </summary>
    /// <returns></returns>
    private IEnumerator LoadData() {
        yield return new WaitForSeconds(2);
        EventManager.TriggerEvent(EventName.LoadData);

    }

    protected override void OnSaveData(EventArg arg)
    {
        // save scene
        var sceneName = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("SceneName", sceneName);

        foreach (string name in destroyedObjectsNames)
        {
            PlayerPrefs.SetString(name, name);
        }
    }

    protected override void OnLoadData(EventArg arg)
    {
        foreach(GameObject objectToSave in objectsToSave)
        {
            var levelObject = PlayerPrefs.GetString(objectToSave.name);
            Debug.Log(levelObject);
            if(!String.IsNullOrEmpty(levelObject))
            {
                Destroy(objectToSave);
            }
        }
    }

    /// <summary>
    /// Add level object to save list
    /// </summary>
    /// <param name="arg"></param>
    private void OnAddToGameLevelObjectsList(EventArg arg)
    {
        var levelObject = arg.GameObject;
        objectsToSave.Add(levelObject);
    }
}
