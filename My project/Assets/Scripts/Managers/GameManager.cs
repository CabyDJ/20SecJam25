using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    private GameObject uiManagerGO;
    private UIManager uiManager;

    float timeLimit = 0;
    bool doubleScore = false;

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
        score = 0;
        time = 20;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        //Debug.Log(time);

        if (time <= timeLimit)
        {
            Debug.Log("Time out!");
            // Do what you want
        }
    }

    public void ChangeScore(int value)
    {
        int v = value;

        if (doubleScore)
            v = v * 2;

        score += v;
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
}
