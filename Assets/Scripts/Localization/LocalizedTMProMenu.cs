using UnityEngine;
using TMPro;

public class LocalizedTMProMenu : LocalizedTMPro
{

    protected override void Localize() {

        // change font asset before localize if it's Menu and language is Russian
        if (LocalizationManager.Language == SystemLanguage.Russian.ToString()) {
            text.font = Resources.Load<TMP_FontAsset>("Fonts/Silver SDF Menu");

            // temp fix bug with text position after changing font asset
            // only in string with two words more
             if(transform.gameObject.name == "New Game") {
                transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y + 3);
            }
        }

        GetComponent<TextMeshProUGUI>().text = LocalizationManager.Localize(localizationKey, gameObject.name);
    }

}
