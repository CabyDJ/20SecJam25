using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour
{

    private Rigidbody2D rb;
    public PlayerInputHandler inputHandler;
    private Vector2 movement = Vector2.right;
    public float moveSpeed = 50f;
    public float dashImpulse = 150f;
    public float dashCooldown = 2f;
    private bool dashReady;

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

        rb.AddForce(movement * moveSpeed);

        if (dashReady && inputHandler.DashInput)
        {
            StartDash();
        }

    }

    private void FixedUpdate()
    {
        
    }

    private void StartDash()
    {
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
}
