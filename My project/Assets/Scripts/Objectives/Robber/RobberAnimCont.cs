using UnityEngine;

public class RobberAnimCont : MonoBehaviour
{
    [SerializeField]
    RobberController robCont;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ActiveHB()
    {
        robCont.ActiveHB();
    }

    private void GrabPiggy()
    {
        robCont.GrabPiggy();
    }
    private void PiggyInABaggy()
    {
        robCont.PiggyBag();
    }
    private void GetOut()
    {
        robCont.StartExiting();
    }
    private void HideRobber()
    {
        robCont.HideRobber();
    }
}
