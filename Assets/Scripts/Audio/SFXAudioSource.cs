using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXAudioSource : GameAudioSource<SFXClipName>
{
    public override void Play(SFXClipName name) {
        source.PlayOneShot(audioClips[name]);
    }
}
