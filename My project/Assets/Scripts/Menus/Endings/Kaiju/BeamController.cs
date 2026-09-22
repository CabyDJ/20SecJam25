using System.Collections;
using UnityEngine;

public class BeamController : MonoBehaviour
{
    [SerializeField]
    private Animator beamAnimator;
    [SerializeField]
    private GameObject flyBeamed;
    [SerializeField]
    private GameObject explosions;

    [SerializeField]
    private KaijuScene3Controller scene3Cont;
    [SerializeField]
    private FlashFade explosionsFade;

    public void StartBeam()
    {
        //DELETE?
    }

    public IEnumerator StopBeam() //call from children beam object
    {
        //flyBeamed.SetActive(false);
        //scene3Cont.FinishLaserAnimation();

        //explosionsFade.StartFadeIn(0.15f);
        yield return new WaitForSeconds(0.25f);
        StartExplosions();
    }

    public void StartExplosions()
    {
        //Time.timeScale = 0.1f;
        explosions.SetActive(true);
    }

    public void StopExplosion()
    {
        explosions.SetActive(false);
        scene3Cont.FinishLaserAnimation();
        explosionsFade.StartFadeOut(0.5f);
    }
}
