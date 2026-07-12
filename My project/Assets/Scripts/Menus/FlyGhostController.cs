using System.Collections;
using UnityEngine;

public class FlyGhostController : MonoBehaviour
{
    [SerializeField]
    private GameObject haloGO;
    [SerializeField]
    private Animator haloAnimator;
    [SerializeField]
    private Animator posAnimator;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGoHeaven()
    {
        //StartCoroutine(TimingHeavenCoroutine());
        StartGhostAscend();
    }

    public void StartGoHell()
    {
        StartCoroutine(TimingHellCoroutine());
    }

    private IEnumerator TimingHellCoroutine()
    {
        yield return new WaitForSeconds(0.2f);
        StartHaloBurn();
        yield return new WaitForSeconds(0.8f);
        StartGhostDraggedToHell();
    }

    private void StartHaloBurn()
    {
        //haloGO.transform.parent = null;
        haloAnimator.Play("HaloBurn");
    }

    private void StartGhostDraggedToHell()
    {
        animator.Play("GhostDown");
        posAnimator.Play("GhostPosDown");
    }
    private void StartGhostAscend()
    {
        posAnimator.Play("GhostPosUp");
        //animator.Play("GhostUp");
    }
}
