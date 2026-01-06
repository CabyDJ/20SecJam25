using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HighlightText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{

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
        text.color = highlightColor;
        text.fontSize = highlightedSize;

        selectable.Select();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = originalColor;
        text.fontSize = originalSize;

        //EventSystem.current.SetSelectedGameObject(null);
    }

    public void OnSelect(BaseEventData eventData)
    {
        text.color = highlightColor;
        text.fontSize = highlightedSize; 
    }

    public void OnDeselect(BaseEventData eventData)
    {
        text.color = originalColor;
        text.fontSize = originalSize;
    }
}
