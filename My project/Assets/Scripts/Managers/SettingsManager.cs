using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField]
    private AudioMixerManager audioMixerManager;

    [SerializeField]
    Slider masterSlider;
    [SerializeField]
    Slider soundFXSlider;
    [SerializeField]
    Slider musicSlider;

    [SerializeField]
    TMP_Text masterTextValue;
    [SerializeField]
    TMP_Text FXSTextValue;
    [SerializeField]
    TMP_Text musicTextValue;

    private Animator animator;
    [SerializeField]
    private Animator buttonAnimator;
    [SerializeField]
    private Animator saveSettingsBtnAnimator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetAudioConfig();
        //SetSlidersValue();
    }

    public void SetMasterSlider(float level)
    {
        audioMixerManager.SetMasterVolume(ValueToVolume(level));
        SetSlider(masterSlider, masterTextValue, level);
    }

    public void SetFXSlider(float level)
    {
        audioMixerManager.SetSoundFXVolume(ValueToVolume(level));
        SetSlider(soundFXSlider, FXSTextValue, level);
    }

    public void SetMusicSlider(float level)
    {
        audioMixerManager.SetMusicVolume(ValueToVolume(level));
        SetSlider(musicSlider, musicTextValue, level);
    }

    private void GetAudioConfig()
    {
        float masterVol = PlayerPrefs.GetFloat("MasterVolume", 0f);
        float FXVol = PlayerPrefs.GetFloat("FXVolume", 0f);
        float musicVol = PlayerPrefs.GetFloat("MusicVolume", 0f);

        SetMasterSlider(VolumeToValue(masterVol));
        SetFXSlider(VolumeToValue(FXVol));
        SetMusicSlider(VolumeToValue(musicVol));
    }

    private void SetSlider(Slider slider, TMP_Text sliderText, float value)
    {
        slider.value = value;
        sliderText.text = ((int)Math.Round(value)).ToString() /*VolumeToValue(value).ToString()*/;
    }

    private static float ValueToVolume(float value)
    {
        var normalized = value / 100f;
        var scaled = Mathf.Lerp(0.0001f, 1f, normalized);
        var volume = Mathf.Log10(scaled) * 20f;
        return volume;
    }

    private static float VolumeToValue(float volume)
    {
        var scaled = Mathf.Pow(10, volume / 20f);
        var normalized = Mathf.InverseLerp(0.0001f, 1f, scaled);
        var value = (int)Math.Round(normalized * 100f);
        return value;
    }

    public void DisplaySettings()
    {
        HideSettingsButton();
        animator.Play("EnterSettings");
        ShowSaveSettings();
    }

    public void CloseSettings()
    {
        if (EventSystem.current != null)
            EventSystem.current.SetSelectedGameObject(null);

        animator.Play("ExitSettings");
        ShowSettingsButton();
        audioMixerManager.SaveAudioPrefs();
        HideSaveSettings();
    }

    public void ShowSaveSettings()
    {
        saveSettingsBtnAnimator.Play("ShowSaveButton");
    }

    public void HideSaveSettings()
    {
        saveSettingsBtnAnimator.Play("HideSaveButton");
    }

    public void SetSettingsEvent()
    {
        masterSlider.Select();
    }

    public void ShowSettingsButton()
    {
        buttonAnimator.Play("ShowSettingsButton");
    }

    public void HideSettingsButton()
    {
        buttonAnimator.Play("HideSettingsButton");
    }
}
