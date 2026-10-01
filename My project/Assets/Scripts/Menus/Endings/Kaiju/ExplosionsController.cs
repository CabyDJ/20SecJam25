using UnityEngine;
using System.Collections;

public class ExplosionsController : MonoBehaviour
{
    [SerializeField]
    GameObject[] explosions;

    [SerializeField]
    private FlashFade flyFlashFade;
    Coroutine cor;
    [SerializeField]
    private SpriteRenderer flyFlashSprite;
    private Color c;

    private void Start()
    {
        c = new Color(flyFlashSprite.color.r, flyFlashSprite.color.g, flyFlashSprite.color.b, 0);
    }

    private void StartExplosions()
    {

    }

    public void Detonation()
    {
        if (cor != null)
        {
            StopCoroutine(cor);
            cor = null;
        }

        //STOP FADE
        flyFlashFade.StopFades();
        flyFlashSprite.color = c;

        cor = StartCoroutine(DetonationFlashFade());
    }

    private IEnumerator DetonationFlashFade()
    {

        yield return new WaitForSeconds(0.3f);
        flyFlashFade.StartFadeIn(0.4f);
    }

}