using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using Vuforia;

public class VideoStreamingScript : MonoBehaviour
{
    public RawImage rawImageLeft;
    public RawImage rawImageRight;
    public RawImage rawImage;
    public RawImage rawImageIpad;
    public UnityEngine.UI.Image reticleLeft;
    public UnityEngine.UI.Image reticleRight;
    public UnityEngine.UI.Image reticle;
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;

    public VideoClip tutorialVideo;
    public VideoClip usaVideo;
    public VideoClip brasilVideo;
    public VideoClip kenyaVideo;
    public VideoClip franceVideo;
    public VideoClip chinaVideo;
    public VideoClip indiaVideo;
    public VideoClip wakandaVideo;

    public ImageTarget planetTarget;
    public RayCastShoot rayCastScript;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.EnableAudioTrack(0, true);
        videoPlayer.SetTargetAudioSource(0, audioSource);

        videoPlayer.loopPointReached += OnMovieFinished;
       //StartCoroutine(PlayVideo());
    }

    void OnMovieFinished(VideoPlayer player)
    {
       rayCastScript.EnableRayCast();
    }

    public IEnumerator PlayVideo()
    {
        //rayCastScript.DisableRayCast();
        videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (!videoPlayer.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
        rawImageLeft.texture = videoPlayer.texture;
        rawImageRight.texture = videoPlayer.texture;
        rawImage.texture = videoPlayer.texture;
        rawImageIpad.texture = videoPlayer.texture;
        videoPlayer.Play();
        audioSource.Play();
    }
}
