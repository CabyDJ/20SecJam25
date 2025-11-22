using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour
{

    private Rigidbody2D rb;
    public PlayerInputHandler inputHandler;
    private Vector2 movement = Vector2.down;
    public float moveSpeed = 50f;
    public float dashImpulse = 150f;
    public float dashCooldown = 2f;
    private bool dashReady;
    private bool isStunned;
    public float stunTime = 0.5f;
    [SerializeField]
    private float hitTimePenalty = 2;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputHandler = GetComponent<PlayerInputHandler>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dashReady = true;
    }

    // Update is called once per frame
    void Update()
    {
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

    }

    private void FixedUpdate()
    {
        if (!isStunned)
            rb.AddForce(movement * moveSpeed);
    }

    private void StartDash()
    {
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(movement * dashImpulse, ForceMode2D.Impulse);
        StartCoroutine(StartDashCD());
        inputHandler.SetDash(false);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Debug.Log("HIT PLAYER");
            Vector2 dir = (collision.gameObject.transform.position - transform.position).normalized;
            rb.linearVelocity = Vector2.zero;
            StartCoroutine(StartStunnedCD());
            rb.AddForce(-dir * 200, ForceMode2D.Impulse);
        }
    }
}
