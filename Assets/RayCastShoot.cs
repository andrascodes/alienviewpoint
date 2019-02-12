using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Video;

public class RayCastShoot : MonoBehaviour
{
    private Camera fpsCam;
    public VideoPlayer videoPlayer;
    public Collider Earth;
    public Collider SpaceShip;
    public Collider NorthAmerica;
    public Collider SouthAmerica;
    public Collider Africa;
    public Collider Europe;
    public Collider China;
    public Collider India;
    public Collider Wakanda;
    private VideoStreamingScript streamingScript;

    private bool rayCastEnabled = true;
    private bool firstHit = true;

    // Start is called before the first frame update
    void Start()
    {
        fpsCam = GetComponentInParent<Camera>();
        streamingScript = videoPlayer.GetComponent<VideoStreamingScript>();
    }

    public void EnableRayCast() {
        rayCastEnabled = true;
    }

    public void DisableRayCast()
    {
        rayCastEnabled = false;
    }

    private void ShowVideoUI() {
        streamingScript.rawImageLeft.color = new Color(1f, 1f, 1f, 0.9f);
        streamingScript.rawImageRight.color = new Color(1f, 1f, 1f, 0.9f);
        streamingScript.rawImage.color = new Color(1f, 1f, 1f, 0.9f);
        streamingScript.rawImageIpad.color = new Color(1f, 1f, 1f, 0.9f);

        streamingScript.reticleLeft.color = new Color(1f, 1f, 1f, 0f);
        streamingScript.reticleLeft.transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().color = new Color(1f, 1f, 1f, 0f);
        streamingScript.reticleRight.color = new Color(1f, 1f, 1f, 0f);
        streamingScript.reticleRight.transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().color = new Color(1f, 1f, 1f, 0f);
        streamingScript.reticle.color = new Color(1f, 1f, 1f, 0f);
        streamingScript.reticle.transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().color = new Color(1f, 1f, 1f, 0f);
    }

    private void ShowReticles()
    {
        streamingScript.rawImageLeft.color = new Color(1f, 1f, 1f, 0f);
        streamingScript.rawImageRight.color = new Color(1f, 1f, 1f, 0f);
        streamingScript.rawImage.color = new Color(1f, 1f, 1f, 0f);
        streamingScript.rawImageIpad.color = new Color(1f, 1f, 1f, 0f);

        streamingScript.reticleLeft.color = new Color(1f, 1f, 1f, 0.4f);
        streamingScript.reticleLeft.transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().color = new Color(1f, 1f, 1f, 0.6f);
        streamingScript.reticleRight.color = new Color(1f, 1f, 1f, 0.4f);
        streamingScript.reticleRight.transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().color = new Color(1f, 1f, 1f, 0.6f);
        streamingScript.reticle.color = new Color(1f, 1f, 1f, 0.4f);
        streamingScript.reticle.transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().color = new Color(1f, 1f, 1f, 0.6f);
    }

    // Update is called once per frame
    void Update()
    {
        // end of 3D model in Cube, 3D model end position
        Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

        RaycastHit hit;

        if (rayCastEnabled == true)
        {
            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, 50f))
            {
                if (firstHit == true || hit.collider.Equals(SpaceShip))
                {
                    firstHit = false;
                    Debug.Log("SpaceShip found");
                    videoPlayer.GetComponent<VideoPlayer>().clip = streamingScript.tutorialVideo;
                    StartCoroutine(streamingScript.PlayVideo());
                    ShowVideoUI();
                    rayCastEnabled = false;
                }
                else if (hit.collider.Equals(NorthAmerica))
                {
                    Debug.Log("USA found");
                    videoPlayer.GetComponent<VideoPlayer>().clip = streamingScript.usaVideo;
                    StartCoroutine(streamingScript.PlayVideo());
                    ShowVideoUI();
                    rayCastEnabled = false;
                }
                else if (hit.collider.Equals(SouthAmerica))
                {
                    Debug.Log("Brasil found");
                    videoPlayer.GetComponent<VideoPlayer>().clip = streamingScript.brasilVideo;
                    StartCoroutine(streamingScript.PlayVideo());
                    ShowVideoUI();
                    rayCastEnabled = false;
                }
                else if(hit.collider.Equals(Wakanda))
                {
                    Debug.Log("Wakanda found");
                    videoPlayer.GetComponent<VideoPlayer>().clip = streamingScript.wakandaVideo;
                    StartCoroutine(streamingScript.PlayVideo());
                    ShowVideoUI();
                    rayCastEnabled = false;
                }
                else if (hit.collider.Equals(Africa))
                {
                    Debug.Log("Kenya found");
                    videoPlayer.GetComponent<VideoPlayer>().clip = streamingScript.kenyaVideo;
                    StartCoroutine(streamingScript.PlayVideo());
                    ShowVideoUI();
                    rayCastEnabled = false;
                }
                else if (hit.collider.Equals(Europe))
                {
                    Debug.Log("France found");
                    videoPlayer.GetComponent<VideoPlayer>().clip = streamingScript.franceVideo;
                    StartCoroutine(streamingScript.PlayVideo());
                    ShowVideoUI();
                    rayCastEnabled = false;
                }
                else if (hit.collider.Equals(China))
                {
                    Debug.Log("China found");
                    videoPlayer.GetComponent<VideoPlayer>().clip = streamingScript.chinaVideo;
                    StartCoroutine(streamingScript.PlayVideo());
                    ShowVideoUI();
                    rayCastEnabled = false;
                }
                else if (hit.collider.Equals(India))
                {
                    Debug.Log("India found");
                    videoPlayer.GetComponent<VideoPlayer>().clip = streamingScript.indiaVideo;
                    StartCoroutine(streamingScript.PlayVideo());
                    ShowVideoUI();
                    rayCastEnabled = false;
                }
                else
                {
                    if(videoPlayer.isPlaying)
                    {
                        videoPlayer.Stop();
                    }
                    ShowReticles();
                }
            }
            else
            {
                if (videoPlayer.isPlaying)
                {
                    videoPlayer.Stop();
                }
                ShowReticles();
            }
        }
    }
}
