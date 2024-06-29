using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVolumeAdjust : MonoBehaviour
{
    public AudioSource source;
    public SOGameProgress SOGameProgress;

    private void Awake()
    {
        UpdateAudioVolume();
    }

    public void UpdateAudioVolume()
    {
        source.volume = SOGameProgress.audioVolume;
    }
}
