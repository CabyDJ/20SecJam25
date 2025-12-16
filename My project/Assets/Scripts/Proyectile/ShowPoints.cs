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
        text.text = "+" + points.ToString();
    }
}
