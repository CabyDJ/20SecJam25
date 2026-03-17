using UnityEngine;

public class SquashStretchObject : MonoBehaviour
{
    SpriteRenderer sp;

    Vector3 originalScale;

    private float squashTarget;
    private float stretchTarget;
    private float squashCurrent;
    private float stretchCurrent;

    private float squashTimeTarget;
    private float stretchTimeTarget;
    private float squashTimeCurrent;
    private float stretchTimeCurrent;

    private bool isSquashing;
    private bool isStretching;

    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalScale = transform.localScale;   
    }

    // Update is called once per frame
    void Update()
    {
        if (isSquashing)
        {
            Squash();
        }

        if (isStretching)
        {

        }
    }

    public void StartSquashStretch(float squash, float stretch)
    {
        squashTarget = squash;
        stretchTarget = stretch;

        isSquashing = true;
        isStretching = true;
    }

    private void Squash()
    {

    }
}
