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

    public void StartScene()
    {
        //cam.transform.position = cameraPos;
        //StartCoroutine(SceneCountDown());
        fade.StartFadeOut(2f);

        StartCoroutine(NormalTime());
    }

    private IEnumerator NormalTime()
    {
        yield return new WaitForSeconds(Random.Range(8, 14));
        ChargeBeam();
    }

    private void ChargeBeam()
    {
        //chargeBeam Animations
        StartCoroutine(StartBeam());
    }

    private IEnumerator StartBeam()
    {
        yield return new WaitForSeconds(1f);//change to when finish beam animation? or refactor
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
