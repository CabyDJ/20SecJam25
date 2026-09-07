using UnityEngine;
using System.Collections;

public class KaijuScene2Controller : MonoBehaviour
{
    [SerializeField]
    Ending5Controller endingController;
    [SerializeField]
    Animator cameraAnimator;

    [SerializeField]
    GameObject cam;
    [SerializeField]
    Vector3 cameraPos = new Vector3(0, -56.25f, 0);

    [SerializeField]
    private FadeInOut fade;

    //[SerializeField]
    //private Animator smokeAnim;
    //[SerializeField]
    //private Animator silhouetteAnim;
    [SerializeField]
    private FlySmokeController smokeCont;

    public void StartScene()
    {
        //cam.transform.position = cameraPos;
        StartCoroutine(SceneCountDown());
    }

    private IEnumerator SceneCountDown()
    {
        cameraAnimator.Play("EndScene2Camera");
        fade.StartFadeOut(1f);

        yield return new WaitForSeconds(7f);
        smokeCont.SetDissipate();
        //smokeAnim.Play("SmokeDiss");
        //silhouetteAnim.Play("SilhouetteDiss");

        yield return new WaitForSeconds(3f);
        fade.StartFadeIn(2f);

        yield return new WaitForSeconds(2.1f);
        //Scene 3 START
        endingController.StartScene3();
        //disable scene 
        gameObject.SetActive(false);
    }
}
