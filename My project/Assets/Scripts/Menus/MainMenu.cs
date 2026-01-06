using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public FadeInOut fade;
    private Animator mainMenuAnim;
    [SerializeField]
    private Animator moscaAnim;
    [SerializeField]
    private TutorialController tutorialCont;

    private void Awake()
    {
        mainMenuAnim = GetComponent<Animator>();
    }

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
        fade.StartFadeIn(fade.fadeTime);
        yield return new WaitForSeconds(fade.fadeTime);
        SceneManager.LoadScene("GameScene");
    }

    public void StartTutorial()
    {
        mainMenuAnim.Play("MainMenuOut");
        moscaAnim.Play("MoscaOut");

        tutorialCont.StartTutorial();
    }

    public void StopTutorial()
    {
        moscaAnim.Play("MoscaIn");
        mainMenuAnim.Play("MainMenuIn");
    }

    public void GoToMainMenu()
    {

    }
}
