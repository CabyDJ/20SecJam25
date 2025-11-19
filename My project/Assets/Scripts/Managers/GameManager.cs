using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    private GameObject uiManagerGO;
    private UIManager uiManager;

    float threshold = 0;

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
        Debug.Log(time);

        if (time <= threshold)
        {
            Debug.Log("Time out!");
            // Do what you want
        }
    }

    public void ChangeScore(int value)
    {
        score += value;
    }

    public void ReduceTimer(float t)
    {
        time -= t;
    }
}
