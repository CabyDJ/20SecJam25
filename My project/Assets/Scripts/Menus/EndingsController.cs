using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingsController : MonoBehaviour
{
    [SerializeField]
    Animator cameraAnimator;

    [SerializeField]
    private FadeInOut fade;

    [SerializeField]
    private List<EndingUI> UIElements;
    private int endingValue;

    private Coroutine showUICoroutine;
    private bool pressToShowUI;
    [SerializeField]
    private ScoreInputHandler inputHandler;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pressToShowUI && (inputHandler.ClickInput || inputHandler.SubmitInput || inputHandler.MoveInput))
        {
            ShowUIElements();
        }
    }

    public void StartEnd(int end)
    {
        endingValue = end;
        StartCoroutine(GoUnderground());
        HideUIElements();
    }

    private IEnumerator GoUnderground()
    {
        fade.StartFadeIn(2.5f);
        cameraAnimator.Play("GoDown");
        yield return new WaitForSeconds(3.1f);
        ShowEnding();
        fade.StartFadeOut(8f);
        //showUICoroutine = StartCoroutine();
    }

    private void HideUIElements()
    {
        foreach (EndingUI UI in UIElements)
        {
            UI.DisableUI();
        }
    }

    private void ShowUIElements()//call when player presses a button
    {
        foreach (EndingUI UI in UIElements)
        {
            UI.EnableUI();
        }
        pressToShowUI = false;
    }

    private void ShowEnding()
    {
        //ShowUIElements();
        transform.GetChild(endingValue).gameObject.SetActive(true);
        pressToShowUI = true;
    }

    //private IEnumerator ShowUITimer()
    //{

    //    yield return new WaitForSeconds(10);
    //}

}
