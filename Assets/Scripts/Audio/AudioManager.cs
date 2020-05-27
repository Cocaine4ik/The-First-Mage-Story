using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Audio manager
/// </summary>
public static class AudioManager {

    #region Fields

    static bool initialized = false;
    static AudioSource audioSource;
    static AudioSource loopedAudioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips =
        new Dictionary<AudioClipName, AudioClip>();

    #endregion

    #region Properties

    // Gets whether or not the audio manager has been initialized
    public static bool Initialized {
        get { return initialized; }
    }

    #endregion

    #region Methods

    // Initializes the audio manager
    public static void Initialize(AudioSource source, AudioSource loopedSource) {

        initialized = true;
        audioSource = source;
        loopedAudioSource = loopedSource;
        loopedAudioSource.loop = true;

        audioClips.Add(AudioClipName.MainMenuTheme,
            Resources.Load<AudioClip>("Audio/Music/MainMenuTheme"));
        audioClips.Add(AudioClipName.RainAndThunder,
                    Resources.Load<AudioClip>("Audio/SFX/RainAndThunder"));
        audioClips.Add(AudioClipName.Spirit,
                    Resources.Load<AudioClip>("Audio/Music/Spirit"));
        audioClips.Add(AudioClipName.WindBackground,
                   Resources.Load<AudioClip>("Audio/SFX/WindBackground"));
    }
    //Plays and repat the audio clip with the given name
    public static void PlayInLoop(AudioClipName name) {
        loopedAudioSource.clip = audioClips[name];
        loopedAudioSource.Play();
    }

    // Plays the audio clip with the given name
    public static void Play(AudioClipName name) {

        audioSource.PlayOneShot(audioClips[name]);

    }

    public static void Play(AudioClipName name, float volume) {
        audioSource.PlayOneShot(audioClips[name], volume);

    }
    // Stop playing current clip
    public static void Stop() {

        audioSource.Stop();
        StatusUtils.MusicOn = false;
    }

    // return true if audio clip is plaing
    public static bool IsPlaying() {

        return audioSource.isPlaying;
    }
    #endregion

}