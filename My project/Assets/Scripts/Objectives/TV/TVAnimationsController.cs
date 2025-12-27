using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Random = UnityEngine.Random;

public class TVAnimationsController : MonoBehaviour
{
    Animator animator;
    Coroutine cor;
    Objective objective;

    public GameObject brokenScreenGO;

    public class TVAnimation
    {
        public string name;
        public float time;

        public TVAnimation(string n, float t)
        {
            name = n;
            time = t;
        }
    }

    private List<TVAnimation> anims;

    private void Awake()
    {
        objective = GetComponentInParent<Objective>();
        animator = GetComponent<Animator>();

        anims = new List<TVAnimation>();
        anims.Add(new TVAnimation("TVOff", 20f));
        anims.Add(new TVAnimation("TVTransition", 2f));
        anims.Add(new TVAnimation("TVCar", 4f));
        anims.Add(new TVAnimation("TVCrabby", 5f));
        anims.Add(new TVAnimation("TVGrass", 5f));
        anims.Add(new TVAnimation("TVHomerGrind", 5f));
        anims.Add(new TVAnimation("TVSignal", 3f));
        anims.Add(new TVAnimation("TVTenna", 1.5f));
        anims.Add(new TVAnimation("TVUIIA", 10f));
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objective.PropertyChanged += BoolChangedEvent;
        StartRandomAnim();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator ChangeAnimation(float time)
    {
        yield return new WaitForSeconds(time);
        cor = StartCoroutine(TransitionAnimation());
    }

    private void StartRandomAnim()
    {
        int index = Mathf.FloorToInt(Random.Range(2, anims.Count));
        TVAnimation anim = anims[index];

        animator.Play(anim.name);

        cor = StartCoroutine(ChangeAnimation(anim.time));
    }

    private IEnumerator TransitionAnimation()
    {
        animator.Play("TVTransition");
        yield return new WaitForSeconds(2f);
        StartRandomAnim();
    }

    //public void PlayOffAnimation()//call when destroyed
    //{
    //    StopCoroutine(cor);
    //    animator.Play("TVOff");
    //}

    public void StartBrokenScreen()
    {
        brokenScreenGO.SetActive(true);
    }

    private void BoolChangedEvent(object sender, PropertyChangedEventArgs args)
    {
        StartBrokenScreen();
    }
}
