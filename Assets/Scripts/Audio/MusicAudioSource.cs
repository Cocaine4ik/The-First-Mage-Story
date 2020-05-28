using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicAudioSource : GameAudioSource<MusicClipName> {

    public override void Initialize(AudioSource audioSource, string folderPath, float defaultVolume) {
        base.Initialize(audioSource, folderPath, defaultVolume);
        LoopOn();
    }
}

