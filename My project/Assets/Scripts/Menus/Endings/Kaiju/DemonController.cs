using System.Collections;
using UnityEngine;

public class DemonController : MonoBehaviour
{
    [SerializeField]
    private Animator demonAnimator;

    public void StartLaugh()
    {
        demonAnimator.Play("DemoñoLaugh");
        StartCoroutine(LaughCycle());
    }

    private IEnumerator LaughCycle()
    {
        yield return new WaitForSeconds(2f);
        demonAnimator.Play("DemoñoLaugh2");
        yield return new WaitForSeconds(4);
        demonAnimator.Play("DemoñoLaugh3");
    }
}
