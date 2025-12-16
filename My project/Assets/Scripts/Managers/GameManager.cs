using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    private GameObject uiManagerGO;
    private UIManager uiManager;
    [SerializeField]
    private FadeInOut fade;

    float timeLimit = 0;
    bool doubleScore = false;
    [SerializeField]
    public bool isGameOver;

    [SerializeField]
    public static int finalScore;
    public int score
    {
        get { return _score; }
        set
        {
            _score = value;
            uiManager.UpdateScoreUI(_score);
        }
    }
    [SerializeField]
    private int _score;

    public float time
    {
        get { return _time; }
        set
        {
            _time = value;
            uiManager.UpdateTimeUI(_time);
        }
    }
    [SerializeField]
    private float _time;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        uiManager = uiManagerGO.GetComponent<UIManager>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
        score = 0;
        time = 20; 
        isGameOver = false;

        fade.StartFadeOut();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        //Debug.Log(time);

        if ( time <= timeLimit)
        {
            time = 0;
            //Debug.Log("Time out!");

            finalScore = score;

            if (!isGameOver)
            {
                StartCoroutine(StartSlowmo());
            }

            isGameOver = true;
        }
    }

    public void ChangeScore(int value)
    {
        if (!isGameOver)
        {
            int v = value;

            if (doubleScore)
                v = v * 2;

            score += v;
        }
    }

    public void SetDoubleScore(bool x2)
    {
        doubleScore = x2;
        uiManager.ShowX2UI(x2);
    }

    public void ReduceTimer(float t)
    {
        time -= t;
    }

    public void LoadGame()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;//Put scene name instead
        SceneManager.LoadScene(currentSceneName);
    }

    public void LoadScoreScene()
    {
        SceneManager.LoadScene("ScoreScene");
    }

    private void SetTimeScale(float value)
    {
        Time.timeScale = value;
    }

    private IEnumerator StartSlowmo()
    {
        SetTimeScale(0.4f);
        fade.StartFadeIn();
        yield return new WaitForSecondsRealtime(1f);
        SetTimeScale(0.2f);
        yield return new WaitForSecondsRealtime(1f);
        LoadScoreScene();
        SetTimeScale(1f);
    }
}
