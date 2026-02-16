using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;

public class PlayerScript : MonoBehaviour
{

    private Rigidbody2D rb;
    private PlayerInputHandler inputHandler;

    private Vector2 movement = Vector2.left;
    public float moveSpeed = 50f;
    public float dashImpulse = 150f;
    public float dashCooldown = 2f;
    private bool dashReady;
    private bool isStunned;
    public float stunTime = 0.5f;
    [SerializeField]
    private float hitTimePenalty = 2;
    [SerializeField]
    private GameObject enemyGO;
    private Enemy enemy;
    [SerializeField]
    private SpriteRenderer sprite;
    [SerializeField]
    private Animator animator;
    private CinemachineImpulseSource impulseSource;
    [SerializeField]
    private ParticleSystem tauntParticle;
    [SerializeField]
    private DashController dashCont;

    [SerializeField]
    AudioClip[] dashAudioClips;
    [SerializeField]
    AudioClip[] tauntAudioClips;
    [SerializeField]
    AudioClip[] hitAudioClips;

    GameObject tauntAudioGO;
    [SerializeField]
    AudioSource flyAudioSource;

    private float fadeTime;
    private float currentFlyFadeTime;
    private float fadePercentage;

    private float startVolume;
    private float targetVolume;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputHandler = GetComponent<PlayerInputHandler>();
        enemy = enemyGO.GetComponent<Enemy>();
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dashReady = true;

        startVolume = flyAudioSource.volume;
        targetVolume = 0;
        fadeTime = 0.6f;

        fadePercentage = 0;
        currentFlyFadeTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameOver)
        {
            //SilenceFlySound(); //remove this and just reduce Mixer FX audio when timer ends? (to silence all FX instead of just the Fly sound)
        }

        if (inputHandler.MoveInput != Vector2.zero)
        {
            movement = inputHandler.MoveInput;
        }
        //movement = inputHandler.MoveInput;

        //if (!isStunned)
        //    rb.AddForce(movement * moveSpeed);

        if (dashReady && inputHandler.DashInput)
        {
            StartDash();
        }

        if (inputHandler.TauntInput)
        {
            //enemy.ThrowProjectile();
            StartTaunt();
        }

        CheckFlipSprite();

    }

    private void FixedUpdate()
    {
        if (!isStunned)
            rb.AddForce(movement * moveSpeed);
    }

    private void StartTaunt()
    {
        //StopTauntSound();

        tauntParticle.Play();
        enemy.StartTaunted();
        inputHandler.SetTaunt(false);

        //TAUNT SOUND

        if (tauntAudioGO == null)
        {
            tauntAudioGO = SoundManager.instance.PlaySound(tauntAudioClips, transform, 1f); //delete playing sound early if player taunts again while not finished playing (return and store audiosource object?)
        }
    }

    private void StopTauntSound()
    {
        if (tauntAudioGO != null)
        {
            Destroy(tauntAudioGO);
        }
    }

    private void StartDash()
    {
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(movement * dashImpulse, ForceMode2D.Impulse);

        dashCont.SetDash(transform.position, movement);

        StartCoroutine(StartDashCD());
        inputHandler.SetDash(false);

        //DASH SOUND
        SoundManager.instance.PlaySound(dashAudioClips, transform, 1f);
    }

    private IEnumerator StartDashCD()
    {
        dashReady = false;
        yield return new WaitForSeconds(dashCooldown);
        dashReady = true;
    }

    private IEnumerator StartStunnedCD()
    {
        GameManager.instance.ReduceTimer(hitTimePenalty);
        isStunned = true;
        yield return new WaitForSeconds(stunTime);
        isStunned = false;
    }

    private void CheckFlipSprite()
    {
        animator.SetFloat("Y", movement.y);

        if (movement.x < 0)
        {
            sprite.flipX = false;
        }
        else
        {
            sprite.flipX = true;
        }
    }

    private void GetHit(Vector2 dir)
    {

        rb.linearVelocity = Vector2.zero;
        StartCoroutine(StartStunnedCD());
        rb.AddForce(-dir * 200, ForceMode2D.Impulse);

        CameraShakeManager.instance.CameraShake(impulseSource, dir);

        StopTauntSound();
        SoundManager.instance.PlaySound(hitAudioClips, transform, 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            //Debug.Log("HIT PLAYER");
            Vector2 dir = (collision.gameObject.transform.position - transform.position).normalized; 
            GetHit(dir);
        }
    }

    private void SilenceFlySound()
    {
        fadePercentage = currentFlyFadeTime / fadeTime;

        flyAudioSource.volume = Mathf.Lerp(startVolume, targetVolume, fadePercentage);

        currentFlyFadeTime += Time.deltaTime;
    }
}
