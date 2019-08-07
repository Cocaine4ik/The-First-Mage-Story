using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// An audio source for the entire game
public class AnimationSource : MonoBehaviour {

    /// Awake is called before Start
    /// 
    void Awake() {
        // make sure we only have one of this game object
        // in the game
        if (!AnimationManager.Initialized) {
            // initialize audio manager and persist audio source across scenes
            Animation animationSource = gameObject.AddComponent<Animation>();
            AnimationManager.Initialize(animationSource);
            DontDestroyOnLoad(gameObject);
        }
        else {
            // duplicate game object, so destroy
            Destroy(gameObject);
        }
    }
}