using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class videoPlayerOne : MonoBehaviour
{
    public VideoPlayer videoPlayer;  // Reference to the VideoPlayer component
    public RawImage rawImage;        // Reference to the RawImage component (where the video will be shown)

    private void Start()
    {
        // Ensure the video player is not playing at the start
        videoPlayer.Stop();
        rawImage.gameObject.SetActive(false);  // Hide the RawImage initially
    }

    public void PlayVideo()
    {
        rawImage.gameObject.SetActive(true);  // Show the RawImage
        videoPlayer.Play();  // Start playing the video
    }

    public void StopVideo()
    {
        videoPlayer.Stop();  // Stop the video when done
        rawImage.gameObject.SetActive(false);  // Hide the RawImage
    }
}
