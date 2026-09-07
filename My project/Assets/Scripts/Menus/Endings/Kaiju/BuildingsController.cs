using System.Collections;
using UnityEngine;

public class BuildingsController : MonoBehaviour
{
    [SerializeField]
    private Animator LBuildingAnimator;
    [SerializeField]
    private Animator RBuildingAnimator;
    [SerializeField]
    private KaijuScene3Controller sceneCont;

    protected bool transition;

    public void DestroyBuildings()
    {
        transition = false;

        //LBuildingAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.;

        LBuildingAnimator.Play("BuildingsDest", 0, LBuildingAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime);
        RBuildingAnimator.Play("BuildingsDest", 0, RBuildingAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime);

        StartCoroutine(BuildingsTransition());
    }
    private IEnumerator BuildingsTransition()
    {
        yield return new WaitForSeconds(6f);
        //turn variable to true and when building animation cycle end check for variable and then start transition animation
        transition = true;

        //LBuildingAnimator.Play("BuildingsN", 0, LBuildingAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime);
        //RBuildingAnimator.Play("BuildingsN", 0, RBuildingAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime);
    }

    public void CheckTransition()
    {
        if (transition)
            StartTransition();
    }

    private void StartTransition()
    {
        LBuildingAnimator.Play("BuildingsT");
        RBuildingAnimator.Play("BuildingsT");
    }

    public void NormalBuildings()
    {
        sceneCont.ReturnToNormal();
    }
}
