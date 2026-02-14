using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HighlightIcon : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    [SerializeField]
    AudioClip[] audioClip;
    [SerializeField]
    AudioClip[] pressedAudioClip;

    private Button selectable;
    Animator animator;
    [SerializeField]
    Animator spriteAnimator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        selectable = GetComponent<Button>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ActivateHighlight();

        selectable.Select();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DisableHighlight();

        if (EventSystem.current != null)
        {
            EventSystem.current.SetSelectedGameObject(null);
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        ActivateHighlight();
        SoundManager.instance.PlaySound(audioClip, transform, 1f);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        DisableHighlight();
    }

    public void ActivateHighlight()
    {
        animator.SetBool("isHigh", true);
        spriteAnimator.SetFloat("speed", 2f);
    }
    public void DisableHighlight()
    {
        animator.SetBool("isHigh", false);
        spriteAnimator.SetFloat("speed", 1f);
    }

    public void PressedButton()
    {
        animator.Play("PressedIcon");
        SoundManager.instance.PlaySound(pressedAudioClip, transform, 1f);
    }
}
