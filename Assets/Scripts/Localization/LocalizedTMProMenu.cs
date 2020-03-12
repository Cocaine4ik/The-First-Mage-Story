using UnityEngine;
using TMPro;

public class LocalizedTMProMenu : LocalizedTMPro
{

    protected override void Localize() {

        // change font asset before localize if it's Menu and language is Russian
        if (LocalizationManager.Language == SystemLanguage.Russian.ToString()) {
            text.font = Resources.Load<TMP_FontAsset>("Fonts/Silver SDF Menu");
        }

        GetComponent<TextMeshProUGUI>().text = LocalizationManager.Localize(localizationKey);
    }

}
