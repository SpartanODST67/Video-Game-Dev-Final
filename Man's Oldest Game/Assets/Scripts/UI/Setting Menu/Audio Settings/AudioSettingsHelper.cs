using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioSettingsHelper : AudioSettingsMenu
{

    // Start is called before the first frame update
    void Start()
    {
        masterVolumeSlider.value = PlayerPrefs.GetFloat("Master Volume");
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFX Volume");
        musicVolumeSlider.value = PlayerPrefs.GetFloat("Music Volume");
        SetMasterVolume();
        SetSFXVolume();
        SetMusicVolume();
    }
}
