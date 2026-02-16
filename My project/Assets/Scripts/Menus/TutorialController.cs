using System.Collections;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    [SerializeField]
    MainMenu menu;
    [SerializeField]
    MenuInputHandler playerInput;
    Animator anim;
    [SerializeField]
    Animator speechBubbleAnim;

    //[SerializeField]
    //GameObject movementControls;
    //[SerializeField]
    //GameObject dashControls;
    //[SerializeField]
    //GameObject tauntControls;
    //[SerializeField]
    //GameObject rageControls;

    //private Animator movementControlsAnim;
    //private Animator dashControlsAnim;
    //private Animator tauntControlsAnim;
    //private Animator rageControlsAnim;

    [SerializeField]
    GameObject arrowGO;
    [SerializeField]
    GameObject[] controlsList;
    Animator[] animatorsList;

    int currentControlTutorial = 0;
    bool isTutoring;
    bool canPressToContinue;

    [SerializeField]
    AudioClip[] flyTalkAudioClips;
    [SerializeField]
    AudioClip[] continueTutorialClip;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        animatorsList = new Animator[controlsList.Length];

        for (int i = 0; i < controlsList.Length; i++)
        {
            animatorsList[i] = controlsList[i].GetComponent<Animator>();
        }

        //movementControlsAnim = movementControls.GetComponent<Animator>();
        //dashControlsAnim = dashControls.GetComponent<Animator>();
        //tauntControlsAnim = tauntControls.GetComponent<Animator>();
        //rageControlsAnim = rageControls.GetComponent<Animator>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isTutoring)
        {

            if (canPressToContinue && (playerInput.SubmitInput || playerInput.ClickInput ))
            {
                ContinueTutorial();
            }

        }
    }

    public void StartTutorial()
    {
        isTutoring = true;
        currentControlTutorial = 0;
        StartCoroutine(ShowSpeechBubble());
    }
    public IEnumerator StopTutorial()
    {
        yield return new WaitForSeconds(0.25f);
        HideSpeechBubble();
        yield return new WaitForSeconds(0.25f);
        isTutoring = false;
        menu.StopTutorial();
    }

    private IEnumerator ShowSpeechBubble()
    {
        yield return new WaitForSeconds(1f);
        speechBubbleAnim.Play("SpeechBubbleIn");
        StartCoroutine(ShowNextControls());
    }

    private void HideSpeechBubble()
    {
        speechBubbleAnim.Play("SpeechBubbleOut");
    }

    //private IEnumerator ShowMovementControls()
    //{
    //    yield return new WaitForSeconds(0.5f);
    //    movementControls.SetActive(true);
    //}    

    public void ContinueTutorial()
    {
        currentControlTutorial++;
        SoundManager.instance.PlaySound(continueTutorialClip, transform, 1f);

        StartCoroutine(HideCurrentControls());

        if (currentControlTutorial > controlsList.Length - 1)
        {
            StartCoroutine(StopTutorial());
        }
        //else
        //{
        //    //StartCoroutine(ShowNextControls());
        //    StartCoroutine(HideCurrentControls());
        //}
    }

    private IEnumerator ShowNextControls()
    {
        yield return new WaitForSeconds(0.4f);
        controlsList[currentControlTutorial].SetActive(true);
        animatorsList[currentControlTutorial].Play("controlsIn");

        SoundManager.instance.PlaySound(flyTalkAudioClips[currentControlTutorial], transform, 1f);

        yield return new WaitForSeconds(0.5f);

        canPressToContinue = true;

        if (currentControlTutorial < controlsList.Length - 1)
        {
            arrowGO.SetActive(true);
        }

        //yield return new WaitForSeconds(4.5f);
        //StartCoroutine(HideCurrentControls());
    }

    private IEnumerator HideCurrentControls()
    {
        canPressToContinue = false;
        animatorsList[currentControlTutorial - 1].Play("controlsOut"); 
        arrowGO.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        controlsList[currentControlTutorial - 1].SetActive(false);

        if (currentControlTutorial < controlsList.Length)
            StartCoroutine(ShowNextControls());
        //ContinueTutorial();
    }
}
