using System.Collections;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    [SerializeField] private AudioSource[] audioSources;
    [SerializeField] private AudioSource introAudioSource;
    [SerializeField] private AudioSource loopAudioSource;
    private int audioToggle;

    private AudioClip currentClip;
    [SerializeField]
    private AudioClip[] audioClips;
    private AudioClip introClip;
    private AudioClip loopClip;
    private AudioClip outroClip;

    private double goalTime = 0;
    private double musicDuration;

    private bool queudClip;
    private bool isIntroPlaying;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        //introAudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        //Debug.Log("goaltime: " + goalTime + " " + (float)musicDuration + " " + AudioSettings.dspTime);
        //if (queudClip && AudioSettings.dspTime >= goalTime /*- 1*/)
        //{
        //    //PlayScheduledClip();
        //    //PlayScheduledAudio();
        //}
        //Debug.Log(introClip + " " + isIntroPlaying + " " + introAudioSource.isPlaying);
        if (introClip != null && isIntroPlaying && !introAudioSource.isPlaying)
        {
            PlayScheduledAudio();
        }
    }

    private void PlayScheduledClip()
    {
        audioSources[audioToggle].clip = currentClip;
        audioSources[audioToggle].PlayScheduled(goalTime);

        musicDuration = (double)currentClip.samples / currentClip.frequency;
        goalTime = goalTime + musicDuration;

        audioToggle = 1 - audioToggle;
    }

    private void PlayScheduledAudio()
    {
        PlayLoop(loopClip);
        queudClip = false;
        isIntroPlaying = false;
    }

    public void SetCurrentClip(AudioClip clip)
    {
        currentClip = clip;
    }

    public void PlayIntroAndLoop(AudioClip intro, AudioClip loop)
    {
        introClip = intro;
        loopClip = loop;

        introAudioSource.loop = false;
        introAudioSource.clip = introClip;
        introAudioSource.Play();
        isIntroPlaying = true;

        musicDuration = (double)introClip.samples / introClip.frequency;
        goalTime = AudioSettings.dspTime + musicDuration;

        //loopAudioSource.clip = loopClip;
        //loopAudioSource.PlayScheduled(goalTime);//PLAYSCHEDULED DOESNT WORK ON WEBGL BUILDS :( MAYBE HARDCODE TIME TO INTRO DURATION?

        //loopAudioSource.loop = true;
        //loopAudioSource.clip = loop;

        queudClip = true;
    }

    public void PlayLoop(AudioClip loop)
    {
        loopAudioSource.loop = true;
        loopAudioSource.clip = loop;
        loopAudioSource.Play();
    }

    public void PlayOnce(AudioClip clip)
    {
        introAudioSource.loop = false;
        introAudioSource.clip = clip;
        introAudioSource.Play();
    }

    public void SetAudioPitch(float pitch)
    {
        introAudioSource.pitch = pitch;
    }
}
