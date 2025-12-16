using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public FadeInOut fade;

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    public void PlayGame()
    {
        StartCoroutine(StartFadeIn());
    }

    public IEnumerator StartFadeIn()
    {
        fade.StartFadeIn();
        yield return new WaitForSeconds(fade.fadeTime);
        SceneManager.LoadScene("GameScene");
    }
}
