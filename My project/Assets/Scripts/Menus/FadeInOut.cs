using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    Image img;
    bool isFadingIn;
    bool isFadingOut;
    public float fadeTime = 2f;
    private float currentFadingTime = 0f;
    private float fadePercentage = 0f;

    Color startColor;
    Color targetColor;

    [SerializeField]
    private bool fadeOutFX;
    [SerializeField]
    private bool fadeOutMusic;

    [SerializeField]
    AudioMixerManager audioManager;

    float startFXVolume;
    float targetFXVolume;

    float startMusicVolume;
    float targetMusicVolume;

    private void Awake()
    {
        img = GetComponent<Image>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartFadeOut(fadeTime);
    }

    public void StartFadeOut(float time)
    {
        img.enabled = true;
        startColor = new Color(img.color.r, img.color.g, img.color.b, img.color.a /*1*/);
        targetColor = new Color(img.color.r, img.color.g, img.color.b, 0);

        fadeTime = time;

        isFadingIn = false;
        isFadingOut = true;
        fadePercentage = 0;
        currentFadingTime = 0;
    }

    public void StartFadeIn(float time)
    {
        img.enabled = true;
        startColor = new Color(img.color.r, img.color.g, img.color.b, img.color.a /*0*/);
        targetColor = new Color(img.color.r, img.color.g, img.color.b, 1);

        startFXVolume = audioManager.GetFXVolume();
        targetFXVolume = 0;
        startMusicVolume = audioManager.GetMusicVolume();
        targetMusicVolume = 0;

        fadeTime = time;

        isFadingOut = false;
        isFadingIn = true;
        fadePercentage = 0;
        currentFadingTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFadingOut)
        {
            fadePercentage = currentFadingTime / fadeTime;
            //Debug.Log(fadePercentage);

            img.color = Color.Lerp(startColor, targetColor, fadePercentage);

            if(fadePercentage >= 1)
            {
                //img.enabled = false;
                isFadingOut = false;
                fadePercentage = 0;
                currentFadingTime = 0;
            }
            currentFadingTime += Time.deltaTime;
        }
        else if (isFadingIn)
        {
            fadePercentage = currentFadingTime / fadeTime;
            //Debug.Log(fadePercentage);

            img.color = Color.Lerp(startColor, targetColor, fadePercentage);

            CheckAudioFades();

            if (fadePercentage >= 1)
            {
                //img.enabled = false;
                isFadingIn = false;
                fadePercentage = 0;
                currentFadingTime = 0;
            }
            currentFadingTime += Time.deltaTime;
        }
    }

    //private IEnumerator StartFade()
    //{
    //    yield return new WaitForSeconds();
    //}

    private void CheckAudioFades()
    {
        if (fadeOutFX)
            FadeOutFX();

        if (fadeOutMusic)
            FadeOutMusic();
    }

    private void FadeOutFX()
    {
        audioManager.SetSoundFXVolume(audioManager.ValueToVolume(Mathf.Lerp(startFXVolume, targetFXVolume, fadePercentage)));
    }

    private void FadeOutMusic()
    {
        audioManager.SetMusicVolume(audioManager.ValueToVolume(Mathf.Lerp(startMusicVolume, targetMusicVolume, fadePercentage)));
    }

    //private void FadeInFX()
    //{
    //    audioManager.SetSoundFXVolume(audioManager.ValueToVolume(Mathf.Lerp(startFXVolume, targetFXVolume, fadePercentage)));
    //}

    //private void FadeInMusic()
    //{
    //    audioManager.SetMusicVolume(audioManager.ValueToVolume(Mathf.Lerp(startMusicVolume, targetMusicVolume, fadePercentage)));
    //}

    public void SetImageColor(Color col)
    {
        img.color = col;
    }
}
