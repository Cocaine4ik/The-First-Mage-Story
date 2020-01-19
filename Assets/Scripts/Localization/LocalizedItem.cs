using UnityEngine;

public class LocalizedItem : MonoBehaviour
{
    public string LocalizationKeyName;
    public string LocalizationKeyDescription;

    public void Start() {
        Localize();
        LocalizationManager.LocalizationChanged += Localize;
    }

    public void OnDestroy() {
        LocalizationManager.LocalizationChanged -= Localize;
    }

    private void Localize() {/*
        GetComponent<Item>().LocalizeItemName(LocalizationManager.Localize(LocalizationKeyName));
        GetComponent<Item>().LocalizeItemDescription(LocalizationManager.Localize(LocalizationKeyDescription));*/
    }
}
