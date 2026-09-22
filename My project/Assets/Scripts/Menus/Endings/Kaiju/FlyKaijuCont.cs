using System.Collections;
using UnityEngine;

public class FlyKaijuCont : MonoBehaviour
{
    [SerializeField]
    private Animator flyFaceChargingAnim;
    [SerializeField]
    private Animator flyFaceChargedAnim;
    [SerializeField]
    private Animator flyFaceAnim;
    [SerializeField]
    private Animator windowAnim;

    public void ShowChargeWindow()
    {
        windowAnim.Play("FlyFaceWindowOn");
        flyFaceAnim.Play("FlyFaceCharging");
        flyFaceChargingAnim.Play("ChargingParticlesWindow");
    }

    public void HideChargeWindow()
    {
        windowAnim.Play("FlyFaceWindowOff");
    }

    public void ChargedLaser()
    {
        flyFaceAnim.Play("FlyFaceChargedImpactF");
        //flyFaceChargingAnim.Play("ChargingParticlesTransitionWindow");
        flyFaceChargingAnim.Play("ChargedParticlesStop");
        StartCoroutine(PostChargedEffect());
    }

    public IEnumerator PostChargedEffect()
    {
        yield return new WaitForSeconds(0.5f);
        flyFaceChargedAnim.Play("ChargedParticlesWindow", -1, 0f);
    }
}
