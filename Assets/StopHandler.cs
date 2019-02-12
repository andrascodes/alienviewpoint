using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Vuforia;

public class StopHandler : MonoBehaviour, ITrackableEventHandler
{
    public VideoPlayer videoPlayer;
    public RayCastShoot reticleRayCastScript;
    public RayCastShoot reticleLeftRayCastScript;
    public RayCastShoot reticleRightRayCastScript;
    private TrackableBehaviour mTrackableBehaviour;
    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }

    }

    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            // Play audio when target is found
            videoPlayer.Stop();
            reticleRayCastScript.EnableRayCast();
            reticleLeftRayCastScript.EnableRayCast();
            reticleRightRayCastScript.EnableRayCast();
            //videoPlayer.clip = null;
        }
        else
        {
            // StartCoroutine(streamingScript.PlayVideo());
            // Stop audio when target is lost

        }
    }
}