using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    [SerializeField] private AudioSource[] audioSources;
    [SerializeField] private AudioSource audioSource;
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

    private void Awake()
    {
        if (instance == null)
            instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (queudClip && AudioSettings.dspTime > goalTime /*- 1*/)
        {
            //PlayScheduledClip();
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
    }

    public void SetCurrentClip(AudioClip clip)
    {
        currentClip = clip;
    }

    public void PlayIntroAndLoop(AudioClip intro, AudioClip loop)
    {
        introClip = intro;
        loopClip = loop;

        audioSource.loop = false;
        audioSource.clip = introClip;
        audioSource.Play();

        musicDuration = (double)introClip.samples / introClip.frequency;
        goalTime = AudioSettings.dspTime + musicDuration;

        queudClip = true;
    }

    public void PlayLoop(AudioClip loop)
    {
        audioSource.loop = true;
        audioSource.clip = loop;
        audioSource.Play();
    }

    public void PlayOnce(AudioClip clip)
    {
        audioSource.loop = false;
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void SetAudioPitch(float pitch)
    {
        audioSource.pitch = pitch;
    }
}
