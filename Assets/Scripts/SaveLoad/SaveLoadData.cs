using UnityEngine;

public abstract class SaveLoadData : MonoBehaviour
{
    protected void OnEnable() {
        EventManager.StartListening(EventName.SaveData, OnSaveData);
        EventManager.StartListening(EventName.LoadData, OnLoadData);
    }
    protected void OnDisable() {
        EventManager.StopListening(EventName.SaveData, OnSaveData);
        EventManager.StopListening(EventName.LoadData, OnLoadData);
    }

    protected abstract void OnSaveData(EventArg arg);
    protected abstract void OnLoadData(EventArg arg);

}
