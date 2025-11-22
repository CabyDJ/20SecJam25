using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    GameObject player;
    [SerializeField]
    RageBar rageBar;

    Vector3 moveDir;
    [SerializeField]
    GameObject projectile;

    [SerializeField]
    float baseMoveSpeed = 15f;
    [SerializeField]
    float baseThrowTime = 2f; //throw projectile every X seconds
    float time = 0;

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

    float rageValue = 0;
    bool isPlayerNear = false;
    bool isRage = false;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        moveDir = Vector2.zero;
        //InvokeRepeating(nameof(ThrowProjectile), 2f, throwTime);
        StartCoroutine(HalfTimeBonus());
    }

    void Update()
    {
        ThrowTimer();

        moveDir = (player.transform.position - transform.position).normalized;

        if (isPlayerNear)
            ChangeRageValue(0.1f);
        else
            ChangeRageValue(-0.02f);

        CalculateFinalMoveSpeed();
        CalculateFinalThrowSpeed();
    }

    private void FixedUpdate()
    {
        rb.AddForce(moveDir * (/*moveSpeed **/ totalMoveSpeedBonus/*moveSpeedBonus*/));
    }

    private void ThrowTimer()
    {
        time += Time.deltaTime;

        if (time >= (/*baseThrowTime -*/ totalThrowSpeedBonus))
        {
            ThrowProjectile();
            time = 0;
        }
    }

    private void ThrowProjectile()
    {
        Proyectile p = Instantiate(projectile, transform.position, transform.rotation, transform.parent).GetComponent<Proyectile>();
        p.player = player;
    }

    private IEnumerator HalfTimeBonus()
    {
        yield return new WaitForSeconds(10);
        moveSpeedBonus += 0.5f;
    }

    private void ChangeRageValue(float value)
    {
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
        if (!isRage && rageValue >= 50)
        {
            GameManager.instance.SetDoubleScore(true);
            isRage = true;
        }
        else if (isRage && rageValue < 50)
        {
            GameManager.instance.SetDoubleScore(false);
            isRage = false;
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
