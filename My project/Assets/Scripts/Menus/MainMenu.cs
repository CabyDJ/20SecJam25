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
    [SerializeField]
    private SettingsManager settingsCont;

    [SerializeField]
    private AudioClip[] audioClips;


    private void Awake()
    {
        mainMenuAnim = GetComponent<Animator>();
    }

    private void Start()
    {
        Application.targetFrameRate = 60;

        MusicManager.instance.PlayIntroAndLoop(audioClips[0], audioClips[1]);
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
        MoscaOut();

        tutorialCont.StartTutorial();
        HideMainMenu();
        settingsCont.HideSettingsButton();
    }

    public void StopTutorial()
    {
        MoscaIn();
        ShowMainMenu();
        settingsCont.ShowSettingsButton();
    }

    private void ShowMainMenu()
    {
        mainMenuAnim.Play("MainMenuIn");
    }

    private void HideMainMenu()
    {
        mainMenuAnim.Play("MainMenuOut");
    }

    private void MoscaIn()
    {
        moscaAnim.Play("MoscaIn");
    }

    private void MoscaOut()
    {
        moscaAnim.Play("MoscaOut");
    }

    public void ShowSettings()
    {
        settingsCont.DisplaySettings();
        HideMainMenu();
        MoscaOut();
    }

    public void HideSettings()
    {
        settingsCont.CloseSettings();
        ShowMainMenu();
        MoscaIn();
    }

    public void GoToMainMenu()
    {

    }
}
