using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreMenu : MonoBehaviour
{
    public GameObject finalScoreGO;
    private TMP_Text finalScoreUI;

    private void Awake()
    {
        finalScoreUI = finalScoreGO.GetComponent<TMP_Text>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
        SetScoreValue();
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
        SceneManager.LoadScene("GameScene");
    }
}
