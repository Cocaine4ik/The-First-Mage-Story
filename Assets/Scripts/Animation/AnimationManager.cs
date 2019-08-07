using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimationManager {

    static bool initialized = false;
    static Animation animationSource;
    static Dictionary<AnimationName, AnimationClip> animations =
        new Dictionary<AnimationName, AnimationClip>();

    /// Gets whether or not the audio manager has been initialized
    public static bool Initialized {
        get { return initialized; }
    }

    /// Initializes the audio manager
    public static void Initialize(Animation source) {
        initialized = true;
        animationSource = source;

        animations.Add(AnimationName.MagicArrowImpactEffect, Resources.Load<AnimationClip>("Animations/Effect/Magic-Arrow-Impact-Effect"));
 
    }

    /// Plays the audio clip with the given name
    public static void Play(AnimationName name) {

        Debug.Log("Test");
        animationSource.clip = animations[name];
        animationSource.Play();


    }
}
