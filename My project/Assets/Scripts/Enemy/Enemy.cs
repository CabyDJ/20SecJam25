using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    GameObject player;
    [SerializeField]
    RageBar rageBar;
    [SerializeField]
    Canvas tauntBar;
    private Animator animator;

    public Vector3 moveDir;
    [SerializeField]
    GameObject projectile;
    [SerializeField]
    SpriteRenderer nextProjectileSprite;
    private Proyectile nextProjectile;
    [SerializeField]
    GameObject[] projectiles;

    [SerializeField]
    float baseMoveSpeed = 15f;
    [SerializeField]
    float baseThrowTime = 2f; //throw projectile every X seconds
    float time = 0;
    float burstTime = 0;
    [SerializeField]
    float rapidBurstTime = 0.25f;
    float burstShots = 0;
    float maxBurstShots = 1;

    float moveSpeedBonus = 1f;
    float throwTimeBonus = 1f;
    [SerializeField]
    float rageMoveSpeedMultiplier = 1.3f;
    [SerializeField]
    float rageThrowSpeedMultiplier = 1.25f;
    [SerializeField]
    float totalMoveSpeedBonus = 1;
    [SerializeField]
    float totalThrowSpeedBonus = 1;
    [SerializeField]
    int rageBurstShots = 1;
    [SerializeField]
    int tauntBurstShots = 1;
    [SerializeField]
    float baseBurstShots = 1;
    [SerializeField]
    float tauntCooldown = 4;
    [SerializeField]
    int rageScore = 150;

    float rageValue = 0;
    bool isPlayerNear = false;
    bool canThrow = false;
    //bool isRage = false;
    public bool isRage
    {
        get { return _isRage; }
        set
        {
            _isRage = value;
            CalculateFinalMoveSpeed();
            CalculateFinalThrowSpeed();
            CalculateMaxBurstShots();
        }
    }
    [SerializeField]
    private bool _isRage; 
    public bool isTaunt
    {
        get { return _isTaunt; }
        set
        {
            _isTaunt = value;
            CalculateMaxBurstShots();
        }
    }
    [SerializeField]
    private bool _isTaunt;
    //bool isTaunt = false;
    bool rageBonus = false;

    private Coroutine ProjectileSpriteCor;

    [SerializeField]
    AudioClip[] audioClipsThrow;
    [SerializeField]
    AudioClip[] tauntedAudioClips;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        moveDir = Vector2.zero;
        //InvokeRepeating(nameof(ThrowProjectile), 2f, throwTime);
        //StartCoroutine(HalfTimeBonus());
        //CalculateFinalMoveSpeed();
        //CalculateFinalThrowSpeed();
        isRage = false;
        isTaunt = false;
        GenerateNextProjectile();
    }

    void Update()
    {
        moveDir = (player.transform.position - transform.position).normalized;

        CheckPlayerIsNear();

        //CalculateFinalMoveSpeed();
        //CalculateFinalThrowSpeed();

        ThrowTimer();

        AnimationChanges();
    }

    private void FixedUpdate()
    {
        rb.AddForce(moveDir * (/*moveSpeed **/ totalMoveSpeedBonus/*moveSpeedBonus*/));
    }

    private void AnimationChanges()
    {
        animator.SetFloat("X", moveDir.x);
        animator.SetFloat("Y", moveDir.y);
    }

    private void CheckPlayerIsNear()
    {
        //Debug.Log(Time.deltaTime);
        if (isPlayerNear)
            ChangeRageValue(110f * Time.deltaTime);
        else if (!isPlayerNear)
            ChangeRageValue(-15f * Time.deltaTime);
    }

    private void ThrowTimer()
    {
        time += Time.deltaTime;

        if (/*burstsShot < 3 &&*/ time >= (/*baseThrowTime -*/ totalThrowSpeedBonus))
        {
            //ThrowBurst();
            //time = 0;
            canThrow = true; 
        }

        if (canThrow)
        {
            ThrowBurst();
        }
    }

    private void ThrowBurst()
    {
        //CalculateMaxBurstShots();

        //Proyectile p = Instantiate(projectile, transform.position, transform.rotation, transform.parent).GetComponent<Proyectile>();
        //p.player = player;
        burstTime += Time.deltaTime;

        if (/*burstsShot < 3 && */burstTime >= (/*baseThrowTime -*/ rapidBurstTime))
        {
            ThrowProjectile();
            burstTime = 0;
            burstShots++;

            GenerateNextProjectile();
        }
        else if(burstShots >= maxBurstShots)
        {
            ResetThrowValues();
        }
    }

    private void ResetThrowValues()
    {
        time = 0;
        burstTime = 0;
        burstShots = 0;
        canThrow = false;
    }

    private void GenerateNextProjectile()
    {
        nextProjectile = Instantiate(projectiles[Random.Range(0, projectiles.Length)] /*projectile*/, /*transform.position, transform.rotation,*/ transform).GetComponent<Proyectile>();
        nextProjectile.player = player;

        nextProjectileSprite.sprite = nextProjectile.GetSprite();

        if (ProjectileSpriteCor != null)
            StopCoroutine(ProjectileSpriteCor);

        ProjectileSpriteCor = StartCoroutine(ShowNextProjectileSprite());
    }

    private IEnumerator ShowNextProjectileSprite()
    {
        nextProjectileSprite.enabled = false;
        yield return new WaitForSeconds(0.35f);
        nextProjectileSprite.enabled = true;
    }

    public void ThrowProjectile()
    {
        //Proyectile p = Instantiate(projectiles[Random.Range(0, projectiles.Length)] /*projectile*/, transform.position, transform.rotation, transform.parent).GetComponent<Proyectile>();
        //p.player = player;
        nextProjectile.gameObject.transform.position = nextProjectileSprite.transform.position /*transform.position*/;
        nextProjectile.StartThrow();
        nextProjectileSprite.sprite = null;

        animator.SetBool("isThrowing", true);
        animator.SetFloat("Throw", 1);

        SoundManager.instance.PlaySound(audioClipsThrow, transform, 1f);
    }

    //private IEnumerator HalfTimeBonus()
    //{
    //    yield return new WaitForSeconds(10);
    //    moveSpeedBonus += 0.5f;
    //}

    private void ChangeRageValue(float value)
    {
        if (isTaunt && value > 0)
            value *= 2f;

        rageValue += value;

        if (rageValue > 100)
            rageValue = 100;
        else if (rageValue < 0)
            rageValue = 0;

        //Debug.Log(rageValue);
        rageBar.SetRage(rageValue);

        CheckRageDoubleScore();
    }

    private void CheckRageDoubleScore()
    {
        if (!isRage && rageValue >= 100)
        {
            GameManager.instance.SetDoubleScore(true);
            isRage = true;
            if (!rageBonus)
            {
                rageBonus = true;
                GameManager.instance.ChangeScore(rageScore);
            }
            //CalculateFinalMoveSpeed();
            //CalculateFinalThrowSpeed();
        }
        else if (isRage && rageValue <= 0)
        {
            GameManager.instance.SetDoubleScore(false);
            isRage = false;
            //CalculateFinalMoveSpeed();
            //CalculateFinalThrowSpeed();
        }
    }

    private void CalculateFinalMoveSpeed()
    {
        //totalMoveSpeedBonus = 1;
        totalMoveSpeedBonus = baseMoveSpeed;
        if (isRage)
        {
            totalMoveSpeedBonus *= rageMoveSpeedMultiplier;
        }
    }

    private void CalculateFinalThrowSpeed()
    {
        //totalThrowSpeedBonus = 1;
        totalThrowSpeedBonus = baseThrowTime;
        if (isRage)
        {
            totalThrowSpeedBonus -= (baseThrowTime * rageThrowSpeedMultiplier) - baseThrowTime;
        }
    }

    private void CalculateMaxBurstShots()
    {
        maxBurstShots = baseBurstShots;
        if (isRage)
        {
            maxBurstShots += rageBurstShots;
        }

        if (isTaunt)
            maxBurstShots += tauntBurstShots;
    }

    public void StartTaunted()
    {
        if(!isTaunt)
            StartCoroutine(StartTauntTime());
    }

    private IEnumerator StartTauntTime()
    {
        SoundManager.instance.PlaySound(tauntedAudioClips, transform, 1f);

        time = totalThrowSpeedBonus;
        burstTime = rapidBurstTime;
        //ResetThrowValues();

        isTaunt = true;
        tauntBar.gameObject.SetActive(true);
        yield return new WaitForSeconds(tauntCooldown);
        isTaunt = false;
        tauntBar.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            isPlayerNear = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            isPlayerNear = false;
    }
}
