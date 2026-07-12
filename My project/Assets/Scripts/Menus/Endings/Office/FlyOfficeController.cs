using System.Collections;
using UnityEngine;

public class FlyOfficeController : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    private int num = 7;
    private bool isPanic = false;

    [SerializeField]
    private GameObject boss;
    [SerializeField]
    private Animator bossAnim;

    private AniEnum animEnum;
    public enum AniEnum
    {
        FlyIdle,
        FlyKeyboard,
        FlyMouse,
        FlyLook,
        FlyLookBack,
        FlyAsleep,
        FlySleepy,
        FlySurprise,
        FlyWake
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MouseOrKeyboard()
    {
        GenerateNum();

        CheckNum();
    }

    private void GenerateNum()
    {
        num = Random.Range(1, 11);
    }

    public void CheckNum()
    {
        if (num % 2 == 0)
        {
            //Play Mouse
            PlayAnimation(AniEnum.FlyMouse.ToString());
        }
        else
        {
            //Play KB
            PlayAnimation(AniEnum.FlyKeyboard.ToString());
        }
    }

    public void MouseCheck()
    {
        if (num % 2 == 0 || isPanic)
        {
            PlayAnimation(AniEnum.FlyKeyboard.ToString());
        }
        else
        {
            PlayAnimation(AniEnum.FlySleepy.ToString());
        }
    }

    public void KeyboardCheck()
    {
        if (num % 2 != 0 || isPanic)
        {
            PlayAnimation(AniEnum.FlyMouse.ToString());
        }
        else
        {
            PlayAnimation(AniEnum.FlySleepy.ToString());
        }
    }

    public void StartSleep()
    {
        StartCoroutine(SleepTime());
    }

    private IEnumerator SleepTime()
    {
        yield return new WaitForSeconds(Random.Range(4, 9));
        PlayAnimation(AniEnum.FlyWake.ToString());
    }

    public void LookOutcome()
    {
        if (num < 6)
        {
            PlayAnimation(AniEnum.FlySurprise.ToString());
            boss.SetActive(true);
            bossAnim.Play("BossMovement", -1, 0);
        }
        //else
        //{
        //    PlayAnimation(AniEnum.FlyLookBack.ToString());
        //}
    }

    public void StartPanic()
    {
        StartCoroutine(PanicTimer());
        CheckNum();
    }

    private IEnumerator PanicTimer()
    {
        isPanic = true;
        anim.speed = 2;
        yield return new WaitForSeconds(6);
        anim.speed = 1;
        isPanic = false;
        GenerateNum();
    }

    private void PlayAnimation(string a)
    {
        anim.Play(a);
    }
}
