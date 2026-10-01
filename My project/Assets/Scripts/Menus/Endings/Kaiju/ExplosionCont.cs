using System.Collections;
using UnityEngine;

public class ExplosionCont : MonoBehaviour
{
    [SerializeField]
    private FlashFade flyFlashFade;
    Coroutine cor;
    [SerializeField]
    private SpriteRenderer flyFlashSprite;
    private Color c;

    [SerializeField]
    private ExplosionsController explsCont;

    private void Start()
    {
        c = new Color(flyFlashSprite.color.r, flyFlashSprite.color.g, flyFlashSprite.color.b, 0);
    }

    private void Detonation()
    {
        ////Play sound
        ////flyFlashFade.StartFadeIn(0.95f);

        ////flyFlashFade.StartFadeOut(0.01f);

        //if (cor != null)
        //{
        //    StopCoroutine(cor);
        //    cor = null;
        //}

        //flyFlashSprite.color = c;

        //cor = StartCoroutine(Test());

        explsCont.Detonation();
    }

    private void FinishExpl()
    {
        //this.gameObject.SetActive(false);
    }

    private IEnumerator Test()
    {

        yield return new WaitForSeconds(0.5f);
        flyFlashFade.StartFadeIn(0.5f);
    }

}
