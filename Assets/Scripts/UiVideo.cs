using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiVideo : MonoBehaviour
{   private GameObject _videoParent;
    private GameObject _uiVolumeSlider;
    private GameObject _timelineSlider;
    private GameObject _timer;
    private float _volume;
    private double _time;
    
    private double _duration;
    private string _currentTimeFormatted;
    private string _durationFormatted;

    private float minSliderValue = 0f;
    private float maxSliderValue = 1f;
    void Start()
    {    
        //Get Parent who content video player
      _videoParent  = gameObject.transform.parent.gameObject;

        //Get Volume
      _uiVolumeSlider = gameObject.transform.GetChild(0).gameObject;
      _volume = _videoParent.GetComponent<UnityEngine.Video.VideoPlayer>().GetDirectAudioVolume(0);

        //Get Duration with convert
      _duration = _videoParent.GetComponent<UnityEngine.Video.VideoPlayer>().length;
        int hours = (int)(_duration / 3600);
        int minutes = (int)((_duration % 3600) / 60);
        int seconds = (int)(_duration % 60);
        _durationFormatted = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);

        //Get Volume
      

        //Get TimelineSlider
      _timelineSlider = gameObject.transform.GetChild(1).gameObject;
      _timelineSlider.GetComponent<UnityEngine.UI.Slider>().minValue = minSliderValue;  
      _timelineSlider.GetComponent<UnityEngine.UI.Slider>().maxValue = (float)_duration;
            
        //Get Timer

      _timer = gameObject.transform.GetChild(2).gameObject;
      _timer.GetComponent<TMP_Text>().text = "00:00:00 /" + _duration;     
    }

    
    void Update()
    {
     //Timer   
    _time = _videoParent.GetComponent<UnityEngine.Video.VideoPlayer>().time;
     int hours = (int)(_time / 3600);
    int minutes = (int)((_time % 3600) / 60);
    int seconds = (int)(_time % 60);
    _currentTimeFormatted = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    _timer.GetComponent<TMP_Text>().text = _currentTimeFormatted + " / " + _durationFormatted;

    //Test Last Time
    double lastTime = _videoParent.GetComponent<UnityEngine.Video.VideoPlayer>().frameCount / _videoParent.GetComponent<UnityEngine.Video.VideoPlayer>().frameRate;
        Debug.Log("Last Time: " + lastTime);

    //Timeline Slider
    _timelineSlider.GetComponent<UnityEngine.UI.Slider>().value = (float)_time;  
    }
    }

