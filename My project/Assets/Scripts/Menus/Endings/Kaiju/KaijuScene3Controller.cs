using System.Collections;
using UnityEngine;

public class KaijuScene3Controller : MonoBehaviour
{
    [SerializeField]
    private FadeInOut fade;
    [SerializeField]
    private DemonController demonCont;
    [SerializeField]
    private BuildingsController buildingsCont;
    [SerializeField]
    private FlyKaijuCont flyCont;
    [SerializeField]
    private GameObject beam;
    [SerializeField]
    private FlashFade flashFade;

    public void StartScene()
    {
        //cam.transform.position = cameraPos;
        //StartCoroutine(SceneCountDown());
        fade.StartFadeOut(2f);

        StartCoroutine(NormalTime());
    }

    private IEnumerator NormalTime()
    {
        Debug.Log("Cycle");
        yield return new WaitForSeconds(Random.Range(8, 14));
        StartCoroutine(ChargeBeam());
    }

    private IEnumerator ChargeBeam()
    {
        //chargeBeam Animations
        flyCont.ShowChargeWindow();
        yield return new WaitForSeconds(4f);
        //charged laser
        flyCont.ChargedLaser();
        yield return new WaitForSeconds(1.5f);
        demonCont.StartPointing();
        yield return new WaitForSeconds(1f);
        flashFade.StartFadeIn(0.25f);
        yield return new WaitForSeconds(0.4f);
        StartBeam();
    }

    private void StartBeam()
    {
        beam.SetActive(true);
        flyCont.HideChargeWindow();
    }

    public void FinishLaserAnimation()
    {
        flashFade.StartFadeOut(1f);
        beam.SetActive(false);
        DestroyCity();
    }

    private void DestroyCity()
    {
        demonCont.StartLaugh();
        buildingsCont.DestroyBuildings();

        //StartCoroutine(DestroyedTime());
    }

    public void ReturnToNormal()
    {
        StartCoroutine(NormalTime());
    }
    //private IEnumerator DestroyedTime()
    //{
    //    yield return new WaitForSeconds(Random.Range(8, 14));
    //    ChargeBeam();
    //}
}
