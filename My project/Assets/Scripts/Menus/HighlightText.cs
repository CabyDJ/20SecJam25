using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class HighlightText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public TMP_Text text;

    Color originalColor;
    public Color highlightColor;

    //TMP_Text originalSize; 
    float originalSize; 
    //public TMP_Text highlightedSize; 
    public float highlightedSize;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
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
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = originalColor;
        text.fontSize = originalSize;
    }

}
