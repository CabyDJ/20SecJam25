using System.Collections;
using UnityEngine;

public class SpiderEndingController : BaseEndingController
{
    [SerializeField]
    Animator cameraAnimator;

    [SerializeField]
    GameObject spider;

    [SerializeField]
    GameObject diablaso;

    public override void StartEnding()
    {
        StartMoveTimer();
        StartCoroutine(StartFirstSpider());
        StartCoroutine(StartDiablaso());
    }

    private void StartMoveTimer()
    {
        StartCoroutine(MoveCamera());
    }

    private IEnumerator MoveCamera()
    {
        yield return new WaitForSeconds(2f);
        cameraAnimator.Play("CameraSpider");
    }

    private IEnumerator StartFirstSpider()
    {
        yield return new WaitForSeconds(7);
        spider.SetActive(true);
    }

    private IEnumerator StartDiablaso()
    {
        yield return new WaitForSeconds(Random.Range(17, 21));
        diablaso.SetActive(true);
    }
}
