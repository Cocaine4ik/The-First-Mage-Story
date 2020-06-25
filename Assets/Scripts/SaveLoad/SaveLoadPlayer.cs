using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadPlayer : SaveLoadData
{
    protected override void OnSaveData(EventArg arg) {

        PlayerPrefs.SetFloat("PositionX", Attributes.Instance.transform.position.x);
        PlayerPrefs.SetFloat("PositionY", Attributes.Instance.transform.position.y);

        PlayerPrefs.SetInt("CurrentExp", Attributes.Instance.CurrentExp);
        PlayerPrefs.SetInt("ExpToLevelUp", Attributes.Instance.ExpToLevelUp);
        PlayerPrefs.SetInt("CurrentLevel", Attributes.Instance.CurrentLevel);
    }

    protected override void OnLoadData(EventArg arg) {
        throw new System.NotImplementedException();
    }
}
