using System.Collections;
using UnityEngine;

public class Ending5Controller : BaseEndingController
{
    [SerializeField]
    GameObject BackgroundScene1;
    [SerializeField]
    KaijuScene1Controller scene1Controller;
    [SerializeField]
    GameObject scene1;
    [SerializeField]
    KaijuScene2Controller scene2Controller;
    [SerializeField]
    GameObject scene2;
    [SerializeField]
    KaijuScene3Controller scene3Controller;
    [SerializeField]
    GameObject scene3;
    //[SerializeField]
    //KaijuScene1Controller scene1Controller;
    //[SerializeField]
    //Animator DemonAnimatorScene1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void StartEnding()
    {
        StartScene1();
    }

    private void StartScene1()
    {
        scene1.SetActive(true);
        scene1Controller.StartScene();
    }
    public void StartScene2()
    {
        scene2.SetActive(true);
        scene2Controller.StartScene();
    }
    public void StartScene3()
    {
        scene3.SetActive(true);
        scene3Controller.StartScene();
    }
}
