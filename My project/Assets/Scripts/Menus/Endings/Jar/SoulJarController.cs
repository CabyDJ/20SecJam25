using System.Collections;
using UnityEngine;

public class SoulJarController : MonoBehaviour
{
    private enum Animation
    {
        Soul1,
        Soul2,
        Soul3,
        SoulIdle
    }

    [SerializeField]
    private Animation selectedAnimation;
    [SerializeField]
    private Vector2 spawnRange = new Vector2(1,4);
    private float spawnTime;

    Animator animator;

    //control spawn timing

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCountdown();
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
        spawnTime = Random.Range(spawnRange.x, spawnRange.y);
        yield return new WaitForSeconds(spawnTime);
        PlayAnimation();
    }

    private void PlayAnimation()
    {
        animator.Play(selectedAnimation.ToString());
    }
}
