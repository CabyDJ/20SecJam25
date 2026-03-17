using TMPro;
using UnityEngine;

public class FinalScoreDisplayController : MonoBehaviour
{

    private bool isIncreasingDisplay;
    private float scoreTarget;
    private float scoreCurrent = 0;

    private float increaseTime = 0;
    [SerializeField]
    private float increaseTimeTarget = 4;

    TMP_Text finalScoreUI;
    bool isStretching;
    bool isSquashing;
    //Vector3 targetScale = new Vector3(1.2f, 1.2f, 1);
    float targetScale = 28;
    //Vector3 currentScale;
    float currentScale;
    //Vector3 originalScale;
    float originalScale;
    [Tooltip("How long will each squash/stretch take")]
    [SerializeField]
    float squashStretchTimeTarget = 0.2f;
    float squashStretchTimeCurrent = 0;
    [Tooltip("Emits one particle every time this variable's points have been displayed")]
    [SerializeField]
    float emitParticleEvery = 100;
    float scoreLastEmission = 0;
    [SerializeField]
    ParticleSystem ps;

    // Update is called once per frame
    void Update()
    {
        if (isIncreasingDisplay)
        {
            CheckIncreaseScoreDisplay();
        }

        if (isStretching || isSquashing) {
            SquashStretchText();
        }

    }

    public void StartIncreasingDisplay(float target, TMP_Text UI)
    {
        finalScoreUI = UI;
        //originalScale = finalScoreUI.gameObject.transform.localScale;
        originalScale = finalScoreUI.fontSize;
        currentScale = originalScale;

        scoreTarget = target;
        isIncreasingDisplay = true;
        isStretching = true;

        if(scoreTarget > 0)
            EmitParticle();
    }

    private void CheckIncreaseScoreDisplay()
    {
        increaseTime += Time.deltaTime;

        float increaseCurrentPercent = increaseTime / increaseTimeTarget;
        scoreCurrent = Mathf.SmoothStep(0, scoreTarget, increaseCurrentPercent);
        //scoreCurrent = Mathf.Lerp(0, scoreTarget, EaseOutQuint(increaseCurrentPercent));

        CheckParticleEmission();

        if (scoreCurrent >= scoreTarget)
        {
            scoreCurrent = scoreTarget;
            isIncreasingDisplay = false;
            increaseTime = 0;
            FinalStretch();
        }

        UpdateScore();
    }

    private void UpdateScore()
    {
        finalScoreUI.text = ((int)scoreCurrent).ToString();
    }

    //SOURCE: https://easings.net/en#easeOutQuint From fast to slow
    private float EaseOutQuint(float percentage)
    {
        return 1 - Mathf.Pow(1 - percentage, 5);
    }

    private void SquashStretchText()
    {
        squashStretchTimeCurrent += Time.deltaTime;
        float timePercentage = squashStretchTimeCurrent / squashStretchTimeTarget;

        if (isStretching)
        {
            //float stretchPercentage = currentScale / targetScale;

            currentScale = Mathf.Lerp(currentScale, targetScale, EaseOutQuint(timePercentage));

            if(timePercentage >= 1)
            {
                currentScale = targetScale;
                isStretching = false;
                isSquashing = true;
                squashStretchTimeCurrent = 0;
            }

            finalScoreUI.fontSize = currentScale;
        }
        else if (isSquashing)
        {
            currentScale = Mathf.Lerp(currentScale, originalScale, EaseOutQuint(timePercentage));

            if (timePercentage >= 1)
            {
                currentScale = originalScale;
                isSquashing = false;
                //if (isIncreasingDisplay)
                //    isStretching = true;
                squashStretchTimeCurrent = 0;
            }

            finalScoreUI.fontSize = currentScale;
        }
    }

    private void FinalStretch()
    {
        isStretching = true;
        isSquashing = false;
        squashStretchTimeCurrent = 0;
        //targetScale = 28;
        squashStretchTimeTarget = 2f;
    }

    private void CheckParticleEmission()
    {
        if(scoreCurrent - scoreLastEmission >= emitParticleEvery)
        {
            //Debug.Log(scoreCurrent);
            //scoreLastEmission = scoreCurrent;
            scoreLastEmission += emitParticleEvery;
            isStretching = true;
            isSquashing = false;
            squashStretchTimeCurrent = 0;
            currentScale = originalScale;
            //emite particle
            EmitParticle();
        }
    }

    private void EmitParticle()
    {
        ps.Play();
        //Debug.Log("Emit :)");
    }
}
