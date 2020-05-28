using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Audio manager
/// </summary>
public class AudioManager : MonoBehaviour {

    #region Fields

    private AudioSource musicSource;
    private AudioSource backgroundThemeSource;
    private AudioSource sFXSource;

    public static MusicAudioSource MusicAudioSource = new MusicAudioSource();
    public static BackgroundAudioSource BackgroundAudioSource = new BackgroundAudioSource();
    public static SFXAudioSource SFXAudioSource = new SFXAudioSource();

    [Slider(0.0f, 1.0f)]
    [SerializeField] private float musicVolume = 0.0f;
    [Slider(0.0f, 1.0f)]
    [SerializeField] private float backgroundVolume = 0.0f;
    [Slider(0.0f, 1.0f)]
    [SerializeField] private float sFXVolume = 0.0f;

    #endregion

    #region Methods
    private void Awake() {

        if (MusicAudioSource.Initialized && BackgroundAudioSource.Initialized && SFXAudioSource.Initialized) {
            Destroy(gameObject);
        }

        if (!MusicAudioSource.Initialized) {
            musicSource = gameObject.AddComponent<AudioSource>();
            MusicAudioSource.Initialize(musicSource, "Audio/Music/", musicVolume);
        }
        if (!BackgroundAudioSource.Initialized) {
            backgroundThemeSource = gameObject.AddComponent<AudioSource>();
            BackgroundAudioSource.Initialize(backgroundThemeSource, "Audio/Background/", backgroundVolume);
        }
        if (!SFXAudioSource.Initialized) {
            sFXSource = gameObject.AddComponent<AudioSource>();
            SFXAudioSource.Initialize(sFXSource, "Audio/SFX/", sFXVolume);
        }

        DontDestroyOnLoad(gameObject);
    }
    #endregion

}