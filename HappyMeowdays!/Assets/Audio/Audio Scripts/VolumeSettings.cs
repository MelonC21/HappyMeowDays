using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider masterSlider;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;
    [SerializeField] TextMeshProUGUI MasterValue;
    [SerializeField] TextMeshProUGUI MusicValue;
    [SerializeField] TextMeshProUGUI SFXValue;

    const string MIXER_MASTER = "MasterVolume";
    const string MIXER_MUSIC = "MusicVolume";
    const string MIXER_SFX = "SFXVolume";

    // Start is called before the first frame update
     void Awake()
    {
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);

        

    }

    void SetMusicVolume(float value)
    {
        mixer.SetFloat(MIXER_MUSIC, value);
        MusicValue.text = (value + 80).ToString();
    }

    void SetMasterVolume(float value)
    {
        mixer.SetFloat(MIXER_MASTER, value);
        MasterValue.text = (value + 80).ToString();
    }

    void SetSFXVolume(float value)
    {
        mixer.SetFloat(MIXER_SFX, value);
        SFXValue.text = (value + 80).ToString();
    }
}
