using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMixerManager : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;

    private float masterVolume;
    private float FXVolume;
    private float musicVolume;

    private void Start()
    {
        LoadPrefVolumes();
    }

    public void SetMasterVolume(float level)
    {
        masterVolume = level;
        //float vol = Mathf.Log10(level) * 20f;
        //audioMixer.SetFloat("MasterVolume", vol);
        audioMixer.SetFloat("MasterVolume", masterVolume);
        //SaveAudioPref("MasterVolume", level);
    }

    public void SetSoundFXVolume(float level)
    {
        FXVolume = level;
        //float vol = Mathf.Log10(level) * 20f;
        audioMixer.SetFloat("FXVolume", FXVolume);
        //SaveAudioPref("FXVolume", level);
    }

    public void SetMusicVolume(float level)
    {
        musicVolume = level;
        //float vol = Mathf.Log10(level) * 20f;
        audioMixer.SetFloat("MusicVolume", musicVolume);
        //SaveAudioPref("MusicVolume", level);
    }

    public void SaveAudioPrefs()
    {
        SaveAudioPref("MasterVolume", masterVolume);
        SaveAudioPref("FXVolume", FXVolume);
        SaveAudioPref("MusicVolume", musicVolume);
    }

    private void SaveAudioPref(string key, float value) //call this when closing settings, not when changing slider
    {
        PlayerPrefs.SetFloat(key, value);
    }

    public float ValueToVolume(float value)
    {
        var normalized = value / 100f;
        var scaled = Mathf.Lerp(0.0001f, 1f, normalized);
        var volume = Mathf.Log10(scaled) * 20f;
        return volume;
    }

    public float VolumeToValue(float volume)
    {
        var scaled = Mathf.Pow(10, volume / 20f);
        var normalized = Mathf.InverseLerp(0.0001f, 1f, scaled);
        var value = (int)Math.Round(normalized * 100f);
        return value;
    }

    public float GetFXVolume()
    {
        float volume = -6f;
        audioMixer.GetFloat("FXVolume", out volume);
        volume = VolumeToValue(volume);
        return volume;
    }
    public float GetMusicVolume()
    {
        float volume = -6f;
        audioMixer.GetFloat("MusicVolume", out volume);
        volume = VolumeToValue(volume);
        return volume;
    }

    private void LoadPrefVolumes()
    {
        float masterVol = PlayerPrefs.GetFloat("MasterVolume", -6f);
        float FXVol = PlayerPrefs.GetFloat("FXVolume", -6f);
        float musicVol = PlayerPrefs.GetFloat("MusicVolume", -6f);

        SetMasterVolume(masterVol);
        SetSoundFXVolume(FXVol);
        SetMusicVolume(musicVol);
    }
}
