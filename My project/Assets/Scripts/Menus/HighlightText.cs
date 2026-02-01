using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HighlightText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    [SerializeField]
    AudioClip[] audioClip;

    public TMP_Text text;
    private Button selectable;

    Color originalColor;
    public Color highlightColor;

    //TMP_Text originalSize; 
    float originalSize; 
    //public TMP_Text highlightedSize; 
    public float highlightedSize;

    private void Awake()
    {
        text = GetComponentInChildren<TMP_Text>();
        selectable = GetComponent<Button>();
    }

    void Start()
    {
        originalColor = text.color;
        originalSize = text.fontSize;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //text.color = highlightColor;
        //text.fontSize = highlightedSize;
        ActivateHighlight();

        selectable.Select();
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
    }
    public void DisableHighlight()
    {
        text.color = originalColor;
        text.fontSize = originalSize;
    }
}
