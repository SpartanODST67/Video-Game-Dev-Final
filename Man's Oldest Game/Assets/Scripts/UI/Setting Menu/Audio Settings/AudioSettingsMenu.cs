using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettingsMenu : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] protected AudioMixer audioMixer;
    [SerializeField] protected Slider masterVolumeSlider;
    [SerializeField] protected Slider sfxVolumeSlider;
    [SerializeField] protected Slider musicVolumeSlider;

    private void OnEnable()
    {
        masterVolumeSlider.value = PlayerPrefs.GetFloat("Master Volume");
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFX Volume");
        musicVolumeSlider.value = PlayerPrefs.GetFloat("Music Volume");
    }

    private float ConvertToDb(float sliderValue)
    {
        return Mathf.Log10(Mathf.Max(sliderValue, 0.0001f)) * 20;
    }

    public void SetMasterVolume()
    {
        audioMixer.SetFloat("Master Volume", ConvertToDb(masterVolumeSlider.value));
        PlayerPrefs.SetFloat("Master Volume", masterVolumeSlider.value);
    }

    public void SetSFXVolume()
    {
        audioMixer.SetFloat("SFX Volume", ConvertToDb(sfxVolumeSlider.value));
        PlayerPrefs.SetFloat("SFX Volume", sfxVolumeSlider.value);
    }

    public void SetMusicVolume()
    {
        audioMixer.SetFloat("Music Volume", ConvertToDb(musicVolumeSlider.value));
        PlayerPrefs.SetFloat("Music Volume", musicVolumeSlider.value);
    }
}
