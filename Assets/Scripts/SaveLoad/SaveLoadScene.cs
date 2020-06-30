using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadScene : MonoBehaviour
{
    private List<String> destroyedObjectsNames = new List<GameObject>();

    private void OnEnable() {
        EventManager.StartListening(EventName.SaveData, OnSaveData);
        EventManager.StartListening(EventName.LoadScene, OnLoadScene);
        EventManager.StartListening(EventName.SaveDestroyedObject, OnSaveDestroyedObject);
    }

    private void OnDisable() {
        EventManager.StopListening(EventName.SaveData, OnSaveData);
        EventManager.StopListening(EventName.LoadScene, OnLoadScene);
        EventManager.StopListening(EventName.SaveDestroyedObject, OnSaveDestroyedObject);
    }

    public void OnSaveData(EventArg arg) {
        var sceneName = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("SceneName", sceneName);
        foreach(GameObject in )
    }
    public void OnLoadScene(EventArg arg) {

        var sceneName = PlayerPrefs.GetString("SceneName");
        Debug.Log("Loading scene: " +  sceneName);
        SceneManager.LoadScene(sceneName);
        StartCoroutine(LoadData());
    }
    private void OnSaveDestroyedObject(EventArg arg) {
        var destroyedObject = arg.GameObject;
        destroyedObjects.Add(destroyedObject);
    }
    private IEnumerator LoadData() {
        yield return new WaitForSeconds(2);
        EventManager.TriggerEvent(EventName.LoadData);
    }
}
