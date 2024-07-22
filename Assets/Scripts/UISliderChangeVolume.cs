using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISliderChangeVolume : MonoBehaviour
{
    public SOGameProgress SOGameProgress;
    public Slider slider;
    public AudioVolumeAdjust volumeAdjust;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        slider.value = SOGameProgress.audioVolume;
    }

    public void ChangeAudioVolume()
    {
        SOGameProgress.audioVolume = slider.value;
        volumeAdjust.UpdateAudioVolume();
    }
}
