using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HighlightSlider : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    [SerializeField]
    AudioClip[] audioClip;

    Slider slider;
    [SerializeField]
    private TMP_Text text;

    Color originalColor;
    public Color highlightColor;

    float originalSize;
    public float highlightedSize;

    [SerializeField]
    private GameObject flyIcon;
    private Animator flyAnimator;
    private Image flySprite;
    private Color flyIconColorSelected;
    private Color flyIconColorIdle;
    [SerializeField]
    private flyIconAnim flyAnimation;
    private enum flyIconAnim
    {
        FlyMaster,
        FlyMusic,
        FlySound
    }

    [SerializeField]
    private AudioSource audioWhileSelected;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        flyAnimator = flyIcon.GetComponentInChildren<Animator>();
        flySprite = flyIcon.GetComponentInChildren<Image>();

        flyIconColorIdle = flySprite.color;
        flyIconColorSelected = flyIconColorIdle;
        flyIconColorSelected.a = 255f;
    }

    private void Start()
    {
        originalColor = text.color;
        originalSize = text.fontSize;
        flyAnimator.Play(flyAnimation.ToString());
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //text.color = highlightColor;
        //text.fontSize = highlightedSize;
        ActivateHighlight();

        slider.Select();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //text.color = originalColor;
        //text.fontSize = originalSize;
        DisableHighlight();

        //selectable.activeGameObject = null;

        if (EventSystem.current != null)
        {
            EventSystem.current.SetSelectedGameObject(null);
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        //text.color = highlightColor;
        //text.fontSize = highlightedSize;
        ActivateHighlight();
        SoundManager.instance.PlaySound(audioClip, transform, 1f);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        //text.color = originalColor;
        //text.fontSize = originalSize;
        DisableHighlight();
    }

    public void ActivateHighlight()
    {
        text.color = highlightColor;
        text.fontSize = highlightedSize;

        flyAnimator.SetFloat("speed", 2f);
        flySprite.color = flyIconColorSelected;

        if (audioWhileSelected != null)
        {
            audioWhileSelected.Play();
        }
    }
    public void DisableHighlight()
    {
        text.color = originalColor;
        text.fontSize = originalSize;

        flyAnimator.SetFloat("speed", 1f);
        flySprite.color = flyIconColorIdle;

        if (audioWhileSelected != null)
        {
            audioWhileSelected.Stop();
        }
    }
}
