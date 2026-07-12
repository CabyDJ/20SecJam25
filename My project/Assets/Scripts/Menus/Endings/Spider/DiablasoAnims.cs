using UnityEngine;

public class DiablasoAnims : MonoBehaviour
{
    [SerializeField]
    private DiablasoController controller;
    [SerializeField]
    private FlyController flyCont;
    [SerializeField]
    private GameObject fireBall;
    [SerializeField]
    private SpriteRenderer smile;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPiti()
    {
        flyCont.GivePiti();
    }

    public void SpawnFire()
    {
        fireBall.SetActive(true);
        fireBall.transform.parent = null;
        //flyCont.LitPiti();
    }

    public void GoAway()
    {
        controller.StartMotion2();
        smile.enabled = true;
    }
}
