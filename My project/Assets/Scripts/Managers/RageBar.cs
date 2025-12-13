using UnityEngine;
using UnityEngine.UI;

public class RageBar : MonoBehaviour
{
    Slider slider;
    [SerializeField]
    Gradient colorGradient;
    [SerializeField]
    Image fill;
    [SerializeField]
    Image BorderImage;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        //BarImage = GetComponent<Image>();
    }

    public void SetRage(float rage)
    {
        slider.value = rage;
        fill.color = colorGradient.Evaluate(slider.normalizedValue);

        if (rage == 0)
        {
            BorderImage.enabled = false;
        }
        else
        {
            BorderImage.enabled = true;
        }
    }
}
