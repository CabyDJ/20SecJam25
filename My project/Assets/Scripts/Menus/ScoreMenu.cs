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

    private void Awake()
    {
        finalScoreUI = finalScoreGO.GetComponent<TMP_Text>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
        SetScoreValue();

        MusicManager.instance.PlayIntroAndLoop(audioClips[0], audioClips[1]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetScoreValue()
    {
        finalScoreUI.text = GameManager.finalScore.ToString();
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
}
