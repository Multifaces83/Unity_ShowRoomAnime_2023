using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
//using UnityEngine.UI;


public class Video : MonoBehaviour
{

    [SerializeField] private GameObject _uiSlider;
    [SerializeField] private GameObject _uiVideo;
    [SerializeField] private Color _alphaColor;
    [SerializeField] private float _popDelay = 3f;
    [SerializeField] private float _depopDelay = 2f;
    private float _count = 0f;
    //private GameObject _slider;

    public void Start()
    {

        gameObject.GetComponent<UnityEngine.Video.VideoPlayer>().SetDirectAudioMute(0, true);
        //Instantiate(_uiSlider, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        //Instantiate(_uiSlider, gameObject.transform);


    }
    public void Update()
    {
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

    public void PopMenu()
    {
        _count += Time.deltaTime;
        if (_count <= 0)
        {
            _uiVideo.SetActive(true);
        }
    }

    public void DePopMenu()
    {
        //timer
        _count -= Time.deltaTime;
        if (_count <= 0)
        {
            _uiVideo.SetActive(false);
            _count = 0f;
        }
    }
}


