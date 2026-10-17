using System.Collections;
using UnityEngine;

public class WindowController : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer rightSpriteRenderer;
    [SerializeField]
    private SpriteRenderer leftSpriteRenderer;
    [SerializeField]
    private Sprite rightDamageSprite;
    [SerializeField]
    private Sprite leftDamageSprite;
    [SerializeField]
    private Sprite rightSprite;
    [SerializeField]
    private Sprite leftSprite;

    [SerializeField]
    private Animator windowAnimLeft;
    [SerializeField]
    private Animator windowAnimRight;

    [SerializeField]
    private Objective windowLeft;
    [SerializeField]
    private Objective windowRight;

    [SerializeField]
    private GameObject windowLeftHB;
    [SerializeField]
    private GameObject windowRightHB;

    private bool isWindowOpen;

    public void OpenWindow()
    {
        if (!isWindowOpen)
        {
            windowAnimLeft.enabled = true;
            windowAnimRight.enabled = true;

            if (windowLeft.isDestroyed)
                windowAnimLeft.Play("WindowBrokenOpeningLeft", 0, 0);
            else
                windowAnimLeft.Play("WindowOpeningLeft", 0, 0);

            if (windowRight.isDestroyed)
                windowAnimRight.Play("WindowBrokenOpeningRight", 0, 0);
            else
                windowAnimRight.Play("WindowOpeningRight", 0, 0);

            windowAnimLeft.SetFloat("speed", 1f);
            windowAnimRight.SetFloat("speed", 1f);

            windowLeftHB.SetActive(false);
            windowRightHB.SetActive(false);

            isWindowOpen = true;
        }

    }

    public void CloseWindow()
    {
        if (isWindowOpen)
        {
            windowAnimLeft.SetFloat("speed", -1f);
            windowAnimRight.SetFloat("speed", -1f);

            if (windowLeft.isDestroyed)
                windowAnimLeft.Play("WindowBrokenOpeningLeft", 0, 1);
            else
                windowAnimLeft.Play("WindowOpeningLeft", 0, 1);

            if (windowRight.isDestroyed)
                windowAnimRight.Play("WindowBrokenOpeningRight", 0, 1);
            else
                windowAnimRight.Play("WindowOpeningRight", 0, 1);

            StartCoroutine(ActiveWindowHB());
        }
    }

    private IEnumerator ActiveWindowHB()
    {

        yield return new WaitForSeconds(0.25f);

        windowLeftHB.SetActive(true);
        windowRightHB.SetActive(true);

        windowAnimLeft.enabled = false;
        windowAnimRight.enabled = false;

        //windowLeft. CHANGE SPRITES TO NORMAL OR BROKEN

        //if (windowLeft.isDestroyed)
        //    leftSpriteRenderer.sprite = leftDamageSprite;
        //else
        //    leftSpriteRenderer.sprite = leftSprite;

        //if (windowRight.isDestroyed)
        //    rightSpriteRenderer.sprite = rightDamageSprite;
        //else
        //    rightSpriteRenderer.sprite = rightSprite;

        isWindowOpen = false;
    }
}
