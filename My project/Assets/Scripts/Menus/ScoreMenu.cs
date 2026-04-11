using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreMenu : MonoBehaviour
{
    public GameObject finalScoreGO;
    private TMP_Text finalScoreUI;
    [SerializeField]
    private FadeInOut fade;

    [SerializeField]
    private Button retryBtn;
    [SerializeField]
    private Button menuBtn;

    [SerializeField]
    private AudioClip[] audioClips;

    [SerializeField]
    private float[] endingScores;

    [SerializeField]
    private ScoreBarController scoreBarController;
    private FinalScoreDisplayController finalScoreController;
    [SerializeField]
    private EndingsController endingsController;
    private int ending = 0;

    private void Awake()
    {
        finalScoreUI = finalScoreGO.GetComponent<TMP_Text>();
        finalScoreController = gameObject.GetComponent<FinalScoreDisplayController>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //GameManager.finalScore = 12789;//TEST
        Application.targetFrameRate = 60;
        //Time.timeScale = .1f;
        StartCoroutine(SetScoreValue());
        SelectEnding();

        StartCoroutine(StartBarIncrease());

        MusicManager.instance.PlayIntroAndLoop(audioClips[0], audioClips[1]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator SetScoreValue()
    {
        yield return new WaitForSeconds(0.5f);
        finalScoreController.StartIncreasingDisplay(GameManager.finalScore, finalScoreUI);
        //finalScoreUI.text = GameManager.finalScore.ToString();
        //GameManager.finalScore 
    }

    public void LoadGameScene()
    {
        retryBtn.enabled = false;
        menuBtn.enabled = false;
        fade.StartFadeIn(0.5f);
        StartCoroutine(FadeLoadGame());
    }

    private IEnumerator FadeLoadGame()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("GameScene");
    }
    public void LoadMainMenuScene()
    {
        retryBtn.enabled = false;
        menuBtn.enabled = false;
        fade.StartFadeIn(2f);
        StartCoroutine(FadeLoadMainMenu());
    }
    private IEnumerator FadeLoadMainMenu()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("MainMenu");
    }

    private void SelectEnding()
    {
        string end = "";

        for (int i = 0; i < endingScores.Length; i++)
        {
            if (GameManager.finalScore >= endingScores[i])
            {
                end = "Ending num " + i;
                ending = i;
            }
        }
        //Debug.Log(end);
    }

    //private void SetScoreBar()
    //{
    //    float percentaje = GameManager.finalScore / endingScores[endingScores.Length - 1];
    //    scoreBar.value = percentaje;
    //    Debug.Log(Mathf.Lerp(endingScores[1], endingScores[endingScores.Length - 1], percentaje));
    //}
    private IEnumerator StartBarIncrease()
    {
        yield return new WaitForSeconds(1.7f);
        scoreBarController.SetScoreBar(endingScores[endingScores.Length - 1]);
    }

    public void WatchEnding()
    {
        //CALLED FROM BUTTON
        //MAKE CAMERA GO DOWN AND FADE IN
        //HIDE UI
        //FADE OUT AND SHOW SCORE DEPENDING ENDING
        endingsController.StartEnd(ending);
    }

    private void ToggleUI(bool toggle)
    {
        //HIDE UI WHILE WATCHING ENDING AND SHOW IT AGAIN AFTER X TIME OR PLAYER PRESSES BUTTON
    }
}
