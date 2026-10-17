using UnityEngine;
using TMPro;

public class ShowPoints : MonoBehaviour
{
    public TMP_Text text;

    private void Awake()
    {
        
    }

    public void SetPoints(int points)
    {
        if (points >= 0f)
            text.text = "+" + points.ToString();
        else
            text.text = points.ToString();
    }
}
