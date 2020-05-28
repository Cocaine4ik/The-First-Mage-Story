using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An audio source for the entire game
/// </summary>
public class GameAudioSource<T> {

    protected bool initialized = false;
    protected AudioSource source;
    protected T clipNames;
    protected Dictionary<T, AudioClip> audioClips = new Dictionary<T, AudioClip>();

    public bool Initialized {
        get { return initialized; }
    }

    public virtual void Initialize(AudioSource audioSource, string folderPath, float defaultVolume) {

        initialized = true;
        source = audioSource;
        source.volume = defaultVolume;
        AddAudioClips(folderPath);
    }
    public virtual void Play(T name) {

        source.clip = audioClips[name];
        source.Play();
    }

    public virtual void Play(T name, float volume) {
        source.volume = volume;
        Play(name);

    }

    public void Stop() {
        source.Stop();
    }
    public bool IsPlaying() {
        return source.isPlaying;
    }

    public void LoopOn() {
        source.loop = true;
    }

    public void SetVolume(float volume) {
        source.volume = volume;
    }
    public void AddAudioClips(string folderPath) {

        foreach (var clipName in Enum.GetNames(typeof(T))) {

            audioClips.Add((T)Enum.Parse(typeof(T), clipName),
                Resources.Load<AudioClip>(folderPath + clipName.ToString()));
            Debug.Log(clipName);
            Debug.Log(folderPath + clipName.ToString());
        }
    }
}