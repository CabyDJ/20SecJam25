using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EndingUI : MonoBehaviour
{
    Animator animator;
    Button btn;

    private void Awake()
    {
        btn = GetComponent<Button>();
        animator = GetComponent<Animator>();
        if(animator == null)
            animator = transform.GetComponentInChildren<Animator>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableUI()
    {
        ToggleInteractableBtn(false);
        StartCoroutine(PlayAnim("HideUI"));
    }
    public void EnableUI()
    {
        ToggleInteractableBtn(true);
        StartCoroutine(PlayAnim("ShowUI"));
    }

    private IEnumerator PlayAnim(string animName)
    {
        yield return new WaitForSeconds(0.25f);
        animator.Play(animName);
    }

    private void ToggleInteractableBtn(bool interactable)
    {
        if (btn != null)
            btn.interactable = interactable;
    }

    public void DisableGameObject()
    {
        gameObject.SetActive(false);
    }

    public void EnableGameObject()
    {
        gameObject.SetActive(true);
    }

}
