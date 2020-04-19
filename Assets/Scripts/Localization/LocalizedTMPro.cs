using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]

public class LocalizedTMPro : MonoBehaviour {

    [SerializeField] protected string localizationKey;
    protected TextMeshProUGUI text;

    public string LocalizationKey => localizationKey;

    public void Start() {

        text = GetComponent<TextMeshProUGUI>();
        ChangeLocalization();

    }
    public void OnDestroy() {
        LocalizationManager.LocalizationChanged -= Localize;
    }

    protected virtual void Localize() {

        GetComponent<TextMeshProUGUI>().text = LocalizationManager.Localize(localizationKey);
    }

    /// <summary>
    ///  Change localization
    /// </summary>
    public void ChangeLocalization() {

        Localize();
        LocalizationManager.LocalizationChanged += Localize;

    }
    /// <summary>
    /// Change localization with new key
    /// </summary>
    /// <param name="key"></param>
    public void ChangeLocalization(string key) {
        localizationKey = key;
        Localize();
        LocalizationManager.LocalizationChanged += Localize;
    }
}