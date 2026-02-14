using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] private AudioSource soundObject;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void PlaySound(AudioClip audioClip, Transform spawnPos, float volume)
    {
        if(audioClip != null)
        {
            AudioSource audioSource = Instantiate(soundObject, spawnPos.position, Quaternion.identity);
            audioSource.clip = audioClip;
            audioSource.volume = volume;
            audioSource.Play();

            Destroy(audioSource.gameObject, audioSource.clip.length);
        }

    }

    public GameObject PlaySound(AudioClip[] audioClip, Transform spawnPos, float volume)
    {
        if (audioClip != null && audioClip.Length > 0)
        {
            int random = Random.Range(0, audioClip.Length);

            AudioSource audioSource = Instantiate(soundObject, spawnPos.position, Quaternion.identity);
            audioSource.clip = audioClip[random];
            audioSource.volume = volume;
            audioSource.Play();

            Destroy(audioSource.gameObject, audioSource.clip.length);

            return audioSource.gameObject;
        }

        return null;
    }

}
