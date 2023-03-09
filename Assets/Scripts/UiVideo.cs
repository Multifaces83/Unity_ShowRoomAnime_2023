using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;

public class UiVideo : MonoBehaviour, IDragHandler
{
    //Custom Design
    [SerializeField] private Color _volumeColor;
    [SerializeField] private Color _timelineColor;
    [SerializeField] private Color _timerColor;
    //Components

    private VideoPlayer _videoParent;
    //private Canvas _canvas;
    private Slider _uiVolumeSlider;
    private Slider _timelineSlider;
    private GameObject _timer;
    private float _volume = 0.3f;
    private double _time;

    private double _duration;
    private string _currentTimeFormatted;
    private string _durationFormatted;

    private float minSliderValue = 0f;
    private float maxSliderValue = 1f;
    private bool _dragging = false;
    void Start()
    {
        //Get Volume Slider
        _uiVolumeSlider = gameObject.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Slider>();
        //_uiVolumeSlider.GetComponent<UnityEngine.UI.Slider>().GetComponentsInChildren<UnityEngine.UI.Image>()[1].color = _volumeColor;
        //_uiVolumeSlider.GetComponent<UnityEngine.UI.Slider>().colors.normalColor = _volumeColor;

        //Get Parent who content video player
        _videoParent = gameObject.transform.parent.gameObject.GetComponent<UnityEngine.Video.VideoPlayer>();

        //Get Volume
        //_uiVolumeSlider = gameObject.transform.GetChild(0).gameObject;
        //_volume = _videoParent.GetComponent<UnityEngine.Video.VideoPlayer>().GetDirectAudioVolume(0);
        //_uiVolumeSlider.GetComponent<UnityEngine.UI.Slider>().value = _volume;
        _uiVolumeSlider.value = _volume;

        //Get Duration with convert
        _duration = _videoParent.length;
        int hours = (int)(_duration / 3600);
        int minutes = (int)((_duration % 3600) / 60);
        int seconds = (int)(_duration % 60);
        _durationFormatted = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);

        //Get TimelineSlider
        _timelineSlider = gameObject.transform.GetChild(1).gameObject.GetComponent<UnityEngine.UI.Slider>();
        _timelineSlider.minValue = minSliderValue;
        _timelineSlider.maxValue = (float)_duration;

        //TimeLine Slider Min
        _timelineSlider.minValue = minSliderValue;
        //Get Timer
        _timer = gameObject.transform.GetChild(2).gameObject;
        _timer.GetComponent<TMP_Text>().text = "00:00:00 /" + _duration;
    }


    void Update()
    {
        //Volume Control
        _videoParent.GetComponent<UnityEngine.Video.VideoPlayer>().SetDirectAudioVolume(0, _uiVolumeSlider.GetComponent<UnityEngine.UI.Slider>().value);

        if (_dragging == false)
        {
            _videoParent.Play();
            //Timer   
            _time = _videoParent.time;
            int hours = (int)(_time / 3600);
            int minutes = (int)((_time % 3600) / 60);
            int seconds = (int)(_time % 60);
            _currentTimeFormatted = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
            _timer.GetComponent<TMP_Text>().text = _currentTimeFormatted + " / " + _durationFormatted;

            //Test Last Time
            //double lastTime = _videoParent.GetComponent<UnityEngine.Video.VideoPlayer>().frameCount / _videoParent.GetComponent<UnityEngine.Video.VideoPlayer>().frameRate;


            //Timeline Slider
            _timelineSlider.value = (float)_time;
            //_timeline ondrag
        }
        else
        {
            _videoParent.Pause();
            _videoParent.time = _timelineSlider.value;
        }

    }


    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.dragging)
        {
            _dragging = true;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _dragging = false;
    }

    private void ConvertTime()
    {

    }
}

