using UnityEngine;

public class ExplosionCont : MonoBehaviour
{
    [SerializeField]
    private FlashFade flyFlashFade;

    private void Detonation()
    {
        //Play sound
        //flyFlashFade.StartFadeIn(0.7f);
    }

    private void FinishExpl()
    {
        //this.gameObject.SetActive(false);
    }

}
