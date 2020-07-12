using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private Image gameLevelPreview;
    [SerializeField] private LocalizedTMPro gameLevelName;
    [SerializeField] private LocalizedTMPro gameLevelDescription;
    [SerializeField] private LocalizedTMPro loadingLabel;

    [SerializeField] private List<Animator> torches;

    private const string gameLevelNameKey = "LoadingScreens.Name.";
    private const string gameLevelDescriptionKey = "LoadingScreens.Description.";
    private const string loadingLabelKey = "LoadingScreens.LoadingLabel";
    private const string pressToStartKey = "LoadingScreens.PressToStart";

    private bool isLoaded = false;

    // Start is called before the first frame update
    void Start()
    {
        var sceneName = SceneManager.GetActiveScene().name;
        //gameLevelPreview.sprite = Resources.Load<Sprite>("Sprites/LoadingScreen/" + sceneName);
        //gameLevelName.ChangeLocalization(gameLevelNameKey + sceneName);
        //gameLevelDescription.ChangeLocalization(gameLevelDescriptionKey + sceneName);
        loadingLabel.ChangeLocalization(loadingLabelKey);

        UnityExtensions.PauseGame();
        AudioListener.pause = true;

        for (int i = 0; i < torches.Count; i++)
        {
            StartCoroutine(BurnTorch((float)i, torches[i]));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isLoaded == true && Input.GetKeyDown(KeyCode.Space))
        {
            UnityExtensions.ResumeGame();
            AudioListener.pause = false;
            Destroy(gameObject);
        }
    }

    private IEnumerator BurnTorch(float delay, Animator torchAnimator)
    {
        yield return new WaitForSecondsRealtime(delay);
        torchAnimator.SetTrigger("Burn");
        if(delay == torches.Count-1)
        {
            isLoaded = true;
            loadingLabel.ChangeLocalization(pressToStartKey);
        }
    }
}
