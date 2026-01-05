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
        fade.StartFadeIn();
        yield return new WaitForSeconds(fade.fadeTime);
        SceneManager.LoadScene("GameScene");
    }

    public void StartTutorial()
    {
        //HIDE MAIN MENU (animate it going up)
        mainMenuAnim.Play("MainMenuOut");
        //MOVE MOSCA ANIMATION DOWN
        moscaAnim.Play("MoscaOut");
        //ENABLE SPEECH BUBBLE
        //SHOW 1ST TUTORIAL
        //PLAY SOUND (WHEN SOUND IS IMPLEMENTED)

        tutorialCont.StartTutorial();
    }

    public void StopTutorial()
    {
        //CLOSE SPEECH BUBBLE
        //MOVE MOSCA ANIMATION BACK AGAIN
        //ENABLE MAIN MENU AGAIN
        moscaAnim.Play("MoscaIn");
        mainMenuAnim.Play("MainMenuIn");
    }

    public void GoToMainMenu()
    {

    }
}
