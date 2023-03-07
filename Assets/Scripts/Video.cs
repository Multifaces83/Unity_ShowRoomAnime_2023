using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
//using UnityEngine.UI;


public class Video : MonoBehaviour
{

[SerializeField] private GameObject _uiSlider;
//private GameObject _slider;

    public void Start()
    {

        gameObject.GetComponent<UnityEngine.Video.VideoPlayer>().SetDirectAudioMute(0, true);        
        //Instantiate(_uiSlider, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        //Instantiate(_uiSlider, gameObject.transform);

        
    }



    public void HoverEnterUnmute()
    {

        gameObject.GetComponent<UnityEngine.Video.VideoPlayer>().SetDirectAudioMute(0, false);
    }
    public void HoverExitMute()
    {

        gameObject.GetComponent<UnityEngine.Video.VideoPlayer>().SetDirectAudioMute(0, true);
    }

    public void PlayVideo()
    {
        gameObject.GetComponent<UnityEngine.Video.VideoPlayer>().Play();
    }
    public void StopVideo()
    {
        gameObject.GetComponent<UnityEngine.Video.VideoPlayer>().Stop();
    }

public void VolumeSlider(){
    //instanciate scrollbar ui element
    

    //gameObject.GetComponent<UnityEngine.Video.VideoPlayer>().SetDirectAudioVolume(0, 0.5f);
}

}


