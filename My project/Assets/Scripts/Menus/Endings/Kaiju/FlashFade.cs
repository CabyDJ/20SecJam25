using UnityEngine;

public class FlashFade : MonoBehaviour
{

    bool isFadingIn;
    bool isFadingOut;
    public float fadeTime = 1f;
    private float currentFadingTime = 0f;
    private float fadePercentage = 0f;

    [SerializeField]
    private SpriteRenderer spr;

    private Color currentA; 
    private Color startColor;
    private Color targetColor;

    public void StartFadeOut(float time)
    {
        //SetAlpha(1f);
        spr.enabled = true;
        startColor = new Color(spr.color.r, spr.color.g, spr.color.b, /*spr.color.a*/ 1);
        targetColor = new Color(spr.color.r, spr.color.g, spr.color.b, 0);


        fadeTime = time;

        isFadingIn = false;
        isFadingOut = true;
        fadePercentage = 0;
        currentFadingTime = 0;
    }

    public void StartFadeIn(float time)
    {
        //SetAlpha(0f);
        spr.enabled = true;
        startColor = new Color(spr.color.r, spr.color.g, spr.color.b, /*spr.color.a*/ 0);
        targetColor = new Color(spr.color.r, spr.color.g, spr.color.b, 1);


        fadeTime = time;

        isFadingOut = false;
        isFadingIn = true;
        fadePercentage = 0;
        currentFadingTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFadingOut)
        {
            fadePercentage = currentFadingTime / fadeTime;
            //Debug.Log(fadePercentage);

            spr.color = Color.Lerp(startColor, targetColor, fadePercentage);

            if (fadePercentage >= 1)
            {
                //img.enabled = false;
                isFadingOut = false;
                fadePercentage = 0;
                currentFadingTime = 0;
            }
            currentFadingTime += Time.deltaTime;
        }
        else if (isFadingIn)
        {
            fadePercentage = currentFadingTime / fadeTime;
            //Debug.Log(fadePercentage);

            spr.color = Color.Lerp(startColor, targetColor, fadePercentage);

            if (fadePercentage >= 1)
            {
                //img.enabled = false;
                isFadingIn = false;
                fadePercentage = 0;
                currentFadingTime = 0;
            }
            currentFadingTime += Time.deltaTime;
        }
    }

    public void StopFades()
    {
        isFadingIn = false;
        isFadingOut = false;
    }

    //private void SetAlpha(float alpha)
    //{
    //    currentA = spr.color;
    //    currentA.a = alpha;

    //    spr.color = currentA;
    //}
}
