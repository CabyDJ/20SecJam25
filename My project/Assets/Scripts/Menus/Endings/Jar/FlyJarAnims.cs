using System.Collections;
using UnityEngine;

public class FlyJarAnims : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer sprite;
    [SerializeField]
    Animator animatorMotion;
    [SerializeField]
    Animator animatorSprite;
    //Jar shake script
    [SerializeField]
    ShakeController shakeController;
    [SerializeField]
    ShakeController shakeControllerFly;

    bool spriteFlip;
    float time = 2.4f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(IdleCountdown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartIdle()
    {
        StartCoroutine(IdleCountdown());
        //sprite.flipX = !sprite.flipX;
        spriteFlip = !spriteFlip;
    }

    public void JarShake()
    {
        shakeController.SetShake();
        shakeControllerFly.SetShake();
    }

    IEnumerator IdleCountdown()
    {
        //animatorMotion.Play("");
        //animatorSprite.Play("");
        yield return new WaitForSeconds(time);
        PlayAnimations();
    }

    void PlayAnimations()
    {
        sprite.flipX = spriteFlip;

        if (spriteFlip)
            animatorMotion.Play("FlyJarCrashMotionFlip");
        else
            animatorMotion.Play("FlyJarCrashMotion");

        animatorSprite.Play("FlyJarCrash");

        time = Random.Range(2f, 3.5f);
    }
}
