using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]

public class LocalizedTMPro : MonoBehaviour {

    [SerializeField] private string localizationKey;

    public void Start() {

        ChangeLocalization();

    }
    public void OnDestroy() {
        LocalizationManager.LocalizationChanged -= Localize;
    }
    private void Localize() {
        GetComponent<TextMeshProUGUI>().text = LocalizationManager.Localize(localizationKey);
    }

    public void ChangeLocalization() {

        Localize();
        LocalizationManager.LocalizationChanged += Localize;

    }

    public void ChangeLocalizationKey(string key) {
        localizationKey = key;
    }
}