using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettingDefault : AudioSettingsMenu
{
    [Range(0.0001f, 1f)]
    [SerializeField] float masterDefault;
    [Range(0.0001f, 1f)]
    [SerializeField] float musicDefault;
    [Range(0.0001f, 1f)]
    [SerializeField] float sfxDefault;

    public void ResetAudio()
    {
        masterVolumeSlider.value = masterDefault;
        musicVolumeSlider.value = musicDefault;
        sfxVolumeSlider.value = sfxDefault;
    }

}
