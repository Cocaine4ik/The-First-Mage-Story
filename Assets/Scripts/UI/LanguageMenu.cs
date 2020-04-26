using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Language Menu 
/// </summary>
public class LanguageMenu : MonoBehaviour
{
   [SerializeField] private List<Button> buttonList;
   [SerializeField] private Button okButton;
   [SerializeField] private TextMeshProUGUI languageName;


    private void Start() {

        foreach(Button button in buttonList) {
            button.onClick.AddListener(() => OnChangeLanguage(button.gameObject.name, button.GetComponentInChildren<TextMeshProUGUI>().color));
        }
        okButton.onClick.AddListener(() => OnSetLanguage(languageName.text));
    
    }
    /// <summary>
    /// Set Application.Language button event
    /// </summary>
    private void OnSetLanguage(string languageName) {
        Debug.Log(languageName);
        switch(languageName) {

            case "English": LocalizationManager.Language = SystemLanguage.English.ToString(); break;
            case "Русский": LocalizationManager.Language = SystemLanguage.Russian.ToString(); break;
            case "Espanol": LocalizationManager.Language = SystemLanguage.Spanish.ToString(); break;
            case "Deutsch": LocalizationManager.Language = SystemLanguage.German.ToString(); break;
            case "Français": LocalizationManager.Language = SystemLanguage.French.ToString(); break; 
                
            default: LocalizationManager.Language = SystemLanguage.Russian.ToString(); break; ;
        }
        Debug.Log(LocalizationManager.Language);
        SceneManager.LoadScene("MainMenu");
    }

    /// <summary>
    /// Set language text and color
    /// </summary>
    /// <param name="language"></param>
    /// <param name="buttonTextColor"></param>
   private void OnChangeLanguage(string language, Color buttonTextColor) {

        languageName.text = language;
        languageName.color = buttonTextColor;
    }
}
