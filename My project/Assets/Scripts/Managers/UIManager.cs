using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject scoreGO;
    private TMP_Text scoreUI;
    [SerializeField]
    private GameObject timeGO;
    private TMP_Text timeUI;

    void Awake()
    {
        scoreUI = scoreGO.GetComponent<TMP_Text>();
        timeUI = timeGO.GetComponent<TMP_Text>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScoreUI(int score)
    {
        Debug.Log(score);
        scoreUI.text = score.ToString();
    }

    public void UpdateTimeUI(float time)
    {
        int t = (int)time;
        double t1 = time;
        Debug.Log(t);
        timeUI.text = time.ToString("F1");
    }
}
