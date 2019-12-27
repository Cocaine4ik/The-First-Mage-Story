using UnityEngine;
using UnityEngine.UI;
using TMPro;

    [RequireComponent(typeof(TextMeshPro))]
    public class LocalizedTextMeshPro : MonoBehaviour {
        public string LocalizationKey;
        public void Start() {
            Localize();
            LocalizationManager.LocalizationChanged += Localize;
        }
        public void OnDestroy() {
            LocalizationManager.LocalizationChanged -= Localize;
        }
        private void Localize() {
            GetComponent<TextMeshPro>().text = LocalizationManager.Localize(LocalizationKey);
        }
    }