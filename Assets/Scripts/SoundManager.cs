using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider VolumeSlider;
    public Toggle OnOffMusic;

    private void OnEnable()
    {
        VolumeSlider.value = 1f;
        OnOffMusic.isOn = true;
    }
    public void ChangeVolume()
    {
        if(VolumeSlider)
        {
            audioSource.volume = VolumeSlider.value;
        }
    }

    public void TurnMusicOnOff()
    {
        if(OnOffMusic.isOn)
        {
            audioSource.mute = false;
        }
        else if (!OnOffMusic.isOn) 
        {
            audioSource.mute = true;
        }
    }

}
