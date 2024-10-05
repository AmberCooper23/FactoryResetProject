using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class LoopVideo : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += OnVideoEnd; 
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        vp.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.Play();
    }

    private void OnDisable()
    {
       videoPlayer.loopPointReached -= OnVideoEnd;
    }
}
