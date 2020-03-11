using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

/// <summary>
/// Language Menu 
/// </summary>
public class LanguageMenu : MonoBehaviour
{

   [SerializeField] private TextMeshProUGUI languageName;

    private string[] languageList = { "English", "Русский", "Espanol", "Deutsch" };
    private string currentLanguage;
    private int languageIndex;

    private void Start() {

        currentLanguage = languageName.text;

        for(int i = 0; i < languageList.Length; i++) {

            if (languageList[i] == currentLanguage) {
                languageIndex = i;
                Debug.Log(i);
            }
        }
    }
    /// <summary>
    /// Set Application.Language button event
    /// </summary>
    public void SetLanguage() {

        switch(currentLanguage) {

            case "English": LocalizationManager.Language = SystemLanguage.English.ToString(); break;
            case "Русский": LocalizationManager.Language = SystemLanguage.Russian.ToString(); break;
            case "Espanol": LocalizationManager.Language = SystemLanguage.Spanish.ToString(); break;
            case "Deutsch": LocalizationManager.Language = SystemLanguage.German.ToString(); break;
            default: LocalizationManager.Language = SystemLanguage.Russian.ToString(); break; ;
        }
        Debug.Log(LocalizationManager.Language);
        SceneManager.LoadScene("MainMenu");
    }

    /// <summary>
    /// Next language button event
    /// </summary>
    public void NextLanguage() {

        if(languageIndex < languageList.Length - 1) {

            currentLanguage = languageList[languageIndex+1];
            languageIndex++;
        }
        else if (languageIndex == languageList.Length - 1) {
            currentLanguage = languageList[0];
            languageIndex = 0;
        }

        languageName.text = currentLanguage;
        Debug.Log(languageIndex);
    }

    /// <summary>
    /// Previous language button event
    /// </summary>
    public void PreviousLanguage() {

        if (languageIndex > 0) {

            currentLanguage = languageList[languageIndex - 1];
            languageIndex--;
        }
        else if (languageIndex == 0) {
            currentLanguage = languageList[languageList.Length - 1];
            languageIndex = languageList.Length - 1;
        }

        languageName.text = currentLanguage;
        Debug.Log(languageIndex);
    }
}
