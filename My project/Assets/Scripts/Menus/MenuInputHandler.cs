using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class MenuInputHandler : MonoBehaviour
{
    [SerializeField]
    MainMenu mainMenu;
    private PlayerInput PlayerInpt { get; set; }
    private InputActionMap MenuMap { get; set; }
    public bool SubmitInput { get; private set; }
    public bool ClickInput { get; private set; }

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
}
