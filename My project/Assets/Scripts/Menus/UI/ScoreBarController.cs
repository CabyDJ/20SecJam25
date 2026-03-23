using UnityEngine;
using UnityEngine.UI;

public class ScoreBarController : MonoBehaviour
{
    private Slider scoreBar;

    private float scoreBarTarget = 0;
    private float scoreBarCurrent = 0;
    private bool isMovingBar;
    private float scoreBarTimeCurrent = 0;
    [SerializeField]
    private float scoreBarTimeTarget = 4;
    float barSpeed = 0;

    [SerializeField]
    private AnimationCurve speedCurve;

    public Animator[] icons;
    public float[] iconsPercentage;
    private int iconArrayValue = 0;

    private void Awake()
    {
        scoreBar = GetComponent<Slider>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMovingBar)
        {
            IncreaseScoreBar();
            IconsEffect();
        }
    }

    public void SetScoreBar(float maxValue)
    {
        scoreBar.maxValue = maxValue;
        //scoreBarTarget = target;
        //scoreBarTarget = GameManager.finalScore /*/ target*/;
        //scoreBar.value = percentaje;
        //Debug.Log(Mathf.Lerp(endingScores[1], endingScores[endingScores.Length - 1], percentaje));
        isMovingBar = true;
    }

    public void SetScoreTarget(float targ)//call when emitting a particle (+ 1.2 time delay?)
    {
        scoreBarTarget += targ;
        //scoreBarTimeCurrent = 0f;
    }

    private void IncreaseScoreBar()
    {
        scoreBarTimeCurrent += Time.deltaTime;
        //scoreBarCurrent += (/*0.25f **/ Time.deltaTime);

        //float timePercentage = Mathf.Lerp(0, scoreBarTimeTarget, scoreBarTimeCurrent);
        float timePercentage = scoreBarTimeCurrent / scoreBarTimeTarget;

        float speedCurve = this.speedCurve.Evaluate(timePercentage /** Time.deltaTime*/);
        //Debug.Log(scoreBarTimeTarget + "<-timeTarg timePerc-> " + timePercentage);
        //Debug.Log(barSpeed + "<-speed-> " + barSpeed);
        //scoreBarCurrent += (speedCurve * Time.deltaTime);
        //scoreBarCurrent += (0.00001f * (Mathf.SmoothStep(0, scoreBarTarget, scoreBarCurrent) * Time.deltaTime));
        //float spd = 4000f;
        //scoreBarCurrent = Mathf.SmoothDamp(scoreBarCurrent, scoreBarTarget, ref spd, 1f);
        //scoreBarCurrent += (speedCurve.Evaluate(scoreBarTime) /** Time.deltaTime*/);

        //float curve = speedCurve.Evaluate(scoreBarCurrent);
        //float curve = speedCurve.Evaluate(scoreBarCurrent);
        //scoreBarCurrent += (curve * Time.deltaTime);

        ////move bar over time vvvv
        //float scoreBarCurrentPercent = scoreBarTimeCurrent / scoreBarTimeTarget;
        ////move bar with smoothing vvvv
        ////scoreBarCurrent = Mathf.SmoothStep(0, scoreBarTarget, scoreBarCurrentPercent);
        ////scoreBarCurrent = Mathf.Lerp(0, scoreBarTarget, EaseOutQuint(scoreBarCurrentPercent));

        //float perc = scoreBarCurrent / scoreBarTarget;
        //scoreBarCurrent = Mathf.Lerp(scoreBarCurrent, scoreBarTarget, EaseOutQuint(perc * scoreBarTimeCurrent));


        //scoreBarCurrent = Mathf.Lerp(scoreBarCurrent, scoreBarTarget, scoreBarTimeCurrent /*EaseOutQuint(scoreBarCurrentPercent)*/);
        //float perc = scoreBarCurrent / scoreBarTarget;
        //scoreBarCurrent = Mathf.Lerp(scoreBarCurrent, scoreBarTarget, EaseOutQuint(scoreBarCurrent));

        scoreBarCurrent = Mathf.SmoothDamp(scoreBarCurrent, scoreBarTarget, ref barSpeed, 0.2f);

        //float sp = 1000f;
        //scoreBarCurrent = Mathf.MoveTowards(scoreBarCurrent, scoreBarTarget, sp * Time.deltaTime);

        scoreBar.value = /*curve*/scoreBarCurrent;

        if (scoreBar.value >= GameManager.finalScore /*scoreBarTimeCurrent >= scoreBarTimeTarget*/)
        {
            scoreBarCurrent = GameManager.finalScore;
            scoreBar.value = GameManager.finalScore;
            isMovingBar = false;
            scoreBarTimeCurrent = 0;
        }
    }
    //SOURCE: https://easings.net/en#easeOutQuint From fast to slow
    private float EaseOutQuint(float percentage)
    {
        return 1 - Mathf.Pow(1 - percentage, 5);
    }

    private void IconsEffect()
    {
        if (scoreBar.value >= iconsPercentage[iconArrayValue])
        {
            icons[iconArrayValue].Play("IconSquashStretch");
            //Debug.Log("reached " + iconsPercentage[iconArrayValue]);
            if (iconArrayValue < iconsPercentage.Length - 1)
                iconArrayValue++;
        }
    }
}
