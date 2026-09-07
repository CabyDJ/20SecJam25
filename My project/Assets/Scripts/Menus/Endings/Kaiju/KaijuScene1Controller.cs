using System.Collections;
using UnityEngine;

public class KaijuScene1Controller : MonoBehaviour
{
    [SerializeField]
    GameObject background;
    [SerializeField]
    DemonsScene1Controller demonsController;
    [SerializeField]
    Ending5Controller endingController;

    [SerializeField]
    private FadeInOut fade;

    public void StartScene()
    {
        StartCoroutine(SceneCountDown());
    }

    private IEnumerator SceneCountDown()
    {

        yield return new WaitForSeconds(6);
        //call demons script and start demon 1 first and then demons 2 and 3
        demonsController.CallDemons();

        yield return new WaitForSeconds(6);
        fade.StartFadeIn(0.5f);
        yield return new WaitForSeconds(0.6f);
        //Scene 2 START
        endingController.StartScene2();
        //disable scene 1
        gameObject.SetActive(false);
    }

}
