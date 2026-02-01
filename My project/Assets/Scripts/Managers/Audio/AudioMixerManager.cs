using UnityEngine;
using UnityEngine.Audio;

public class AudioMixerManager : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;

    private float masterVolume;
    private float FXVolume;
    private float musicVolume;

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
}
