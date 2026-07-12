using System.Collections;
using UnityEngine;

public class SoulController : MonoBehaviour
{
    [SerializeField]
    private enum Animation
    {
        Soul1,
        Soul2,
        Soul3,
        SoulHide
    }

    [SerializeField]
    private Animation selectedAnimation;
    [SerializeField]
    private float spawnTime = 1.2f;

    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //PlayAnimation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartCountdown()
    {
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        //Debug.Log("wait " + spawnTime);
        yield return new WaitForSeconds(spawnTime);
        PlayAnimation();
    }

    private void PlayAnimation()
    {
        animator.Play(selectedAnimation.ToString());
    }
}
