using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HoverEvents : MonoBehaviour
{
    public GameObject videoObject;

    private UnityEngine.Video.VideoPlayer videoPlayer;

    private void Awake()
    {
        videoPlayer = videoObject.GetComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.SetDirectAudioMute(0, true);
    }

    public void OnHoverEnter(XRBaseInteractor interactor)
    {
        videoPlayer.SetDirectAudioMute(0, false);
    }

    public void OnHoverExit(XRBaseInteractor interactor)
    {
        videoPlayer.SetDirectAudioMute(0, true);
    }
}
