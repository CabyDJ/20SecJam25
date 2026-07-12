using UnityEngine;

public class PitiController : MonoBehaviour
{
    [SerializeField]
    private FlyController flyCont;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Ignite()
    {
        flyCont.LitPiti();
    }
}
