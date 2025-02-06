using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class IntroManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject mainMenu;
    public float delayBeforeMainMenu = 1.0f;
    public float playDuration = 3.0f;

    void Start()
    {
        mainMenu.SetActive(false);
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += OnVideoFinished;
            videoPlayer.Play();
        }
        else
        {
            Debug.LogError("VideoPlayer is not assigned!");
        }
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        StartCoroutine(ShowMainMenuAfterDelay());
    }

    private System.Collections.IEnumerator ShowMainMenuAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeMainMenu);
        videoPlayer.gameObject.SetActive(false);
        mainMenu.SetActive(true);
    }
}