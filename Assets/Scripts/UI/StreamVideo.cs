using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;


public class StreamVideo : MonoBehaviour
{
    [SerializeField] private RawImage streamWindow;
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private AudioSource audioSource;

    IEnumerator PlayVideo() {

        videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while(!videoPlayer.isPrepared) {
            yield return waitForSeconds;
            break;
        }
        streamWindow.texture = videoPlayer.texture;
        videoPlayer.Play();
        audioSource.Play();
    }
}
