using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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

    private int emittedParticles = 0;
    [SerializeField]
    private ScoreBarController scoreBarController;
    private List<ParticleData> increaseBarTiming = new List<ParticleData>();
    private List<ParticleData> removeFromList = new List<ParticleData>();
    private float scoreTime = 0;

    public class ParticleData
    {
        public float timeDelay;
        public float score;

        public ParticleData(float time, float score)
        {
            timeDelay = (time - 0.25f);
            this.score = score;
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreTime += Time.deltaTime;
        if (isIncreasingDisplay)
        {
            CheckIncreaseScoreDisplay();
        }

        if (isStretching || isSquashing) {
            SquashStretchText();
        }

    }

    private void LateUpdate()
    {
        if(emittedParticles > 0)
        {
            EmitParticle();
            emittedParticles--;
            increaseBarTiming.Add(new ParticleData(scoreTime + ps.main.duration, 100));
        }

        if (increaseBarTiming.Count > 0)
        {
            foreach (ParticleData p in increaseBarTiming)
            {
                if (p.timeDelay <= scoreTime)
                {
                    scoreBarController.SetScoreTarget(p.score);
                    removeFromList.Add(p);
                }
            }

            foreach (ParticleData t in removeFromList)
            {
                increaseBarTiming.Remove(t);
            }
            removeFromList.Clear();
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
        {
            //Debug.Log("FIRST PARTICLE: " + GameManager.finalScore % 100 );
            EmitParticle();
            increaseBarTiming.Add(new ParticleData(scoreTime + ps.main.duration, GameManager.finalScore % 100));
        }
    }

    private void CheckIncreaseScoreDisplay()
    {
        increaseTime += Time.deltaTime;

        float increaseCurrentPercent = increaseTime / increaseTimeTarget;
        //scoreCurrent = Mathf.SmoothStep(0, scoreTarget, increaseCurrentPercent);
        scoreCurrent = Mathf.SmoothStep(0, scoreTarget, EaseOutSine(increaseCurrentPercent));
        //scoreCurrent = Mathf.Lerp(0, scoreTarget, EaseOutQuint(increaseCurrentPercent));
        //scoreCurrent = Mathf.Lerp(0, scoreTarget, EaseOutSine(increaseCurrentPercent));

        CheckParticleEmission();

        if (scoreCurrent >= scoreTarget)
        {
            isIncreasingDisplay = false;
            scoreCurrent = scoreTarget;
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

    private float EaseOutSine(float x)
    {
        return Mathf.Sin((x * Mathf.PI) / 2);
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
            //EmitParticle();
            emittedParticles++;
            CheckParticleEmission();
            //for (int i = 0; i < emitParticleEvery; i++) { 

            //}
        }
    }

    private void EmitParticle()
    {
        ps.Play();
    }
}
