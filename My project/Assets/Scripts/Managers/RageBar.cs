using UnityEngine;
using UnityEngine.UI;

public class RageBar : MonoBehaviour
{
    Slider slider;
    [SerializeField]
    Gradient colorGradient;
    [SerializeField]
    Image fill;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void SetRage(float rage)
    {
        slider.value = rage;
        fill.color = colorGradient.Evaluate(slider.normalizedValue);
    }
}
