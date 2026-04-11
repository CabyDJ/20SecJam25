using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ScoreInputHandler : MonoBehaviour
{
    private PlayerInput PlayerInpt { get; set; }
    private InputActionMap MenuMap { get; set; }
    public bool SubmitInput { get; private set; }
    public bool ClickInput { get; private set; }
    public bool MoveInput { get; private set; }
    [SerializeField]
    private Button selectable;

    private void Awake()
    {
        PlayerInpt = GetComponent<PlayerInput>();

        MenuMap = PlayerInpt.actions.FindActionMap("Menu");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSubmitInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            StartCoroutine(SetSubmit(true));
        }
    }

    public IEnumerator SetSubmit(bool submit)
    {
        SubmitInput = submit;
        yield return new WaitForEndOfFrame();
        SubmitInput = false;
    }

    public void OnClickInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            StartCoroutine(SetClick(true));
        }
    }

    public IEnumerator SetClick(bool click)
    {
        ClickInput = click;
        yield return new WaitForEndOfFrame();
        ClickInput = false;
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            StartCoroutine(SetMove());
            if (EventSystem.current.currentSelectedGameObject == null)
            {
                DefaultSelect();
            }
        }
    }

    private void DefaultSelect()
    {
            StartCoroutine(SelectDefaultButton());
    }

    public IEnumerator SelectDefaultButton()
    {
        yield return new WaitForEndOfFrame();
        selectable.Select();
    }

    public IEnumerator SetMove()
    {
        MoveInput = true;
        yield return new WaitForEndOfFrame();
        MoveInput = false;
    }
}
