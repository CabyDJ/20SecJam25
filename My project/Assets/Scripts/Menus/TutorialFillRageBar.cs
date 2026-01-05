using UnityEngine;

public class TutorialFillRageBar : MonoBehaviour
{
    public float rageValue = 0f;
    private RageBar rageBar;

    private void Awake()
    {
        rageBar = GetComponent<RageBar>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rageBar.SetRage(rageValue);
    }
}
