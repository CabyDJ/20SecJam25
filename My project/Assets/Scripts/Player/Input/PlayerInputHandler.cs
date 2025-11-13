using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; }
    public Vector2 RawMoveInput { get; private set; }
    public bool DashInput { get; private set; }
    public Coroutine DashCoroutine { get; private set; }
    [SerializeField]
    private float inputHoldTime = 0.2f;

    public InputControl inputDevice { get; private set; }
    public bool UsingController { get; private set; }
    public bool RollInput { get; private set; }
    private PlayerInput PlayerInpt { get; set; }
    private InputActionMap GameplayMap { get; set; }
    private InputActionMap MenuMap { get; set; }

    private void Awake()
    {
        PlayerInpt = GetComponent<PlayerInput>();

        GameplayMap = PlayerInpt.actions.FindActionMap("Gameplay");
        MenuMap = PlayerInpt.actions.FindActionMap("Menu");
    }

    //// Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMoveInput = context.ReadValue<Vector2>();
        MoveInput = RawMoveInput.normalized;
    }

    public void OnDashInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SetDash(true);
            if (DashCoroutine != null)
                StopCoroutine(DashCoroutine);
            DashCoroutine = StartCoroutine(StartDashHoldTime());
        }
    }

    public void SetDash(bool dash)
    {
        DashInput = dash;
    }

    private IEnumerator StartDashHoldTime()
    {
        yield return new WaitForSeconds(inputHoldTime);
        DashInput = false;
    }
}
