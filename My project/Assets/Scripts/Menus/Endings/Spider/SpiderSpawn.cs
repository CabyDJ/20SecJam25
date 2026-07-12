using System.Collections;
using UnityEngine;

public class SpiderSpawn : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    private Vector2 idleTime = new Vector2(5, 12);
    [SerializeField]
    private Vector2 hiddenTime = new Vector2(7, 14); 

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartHideSpider()
    {
        StartCoroutine(HideCountdown());
    }

    private IEnumerator HideCountdown()
    {

        yield return new WaitForSeconds(Random.Range(idleTime.x, idleTime.y));
        HideSpider();
    }

    public void StartShowSpider()
    {
        StartCoroutine(ShowCountdown());
    }
    private IEnumerator ShowCountdown()
    {

        yield return new WaitForSeconds(Random.Range(hiddenTime.x, hiddenTime.y));
        SpawnSpider();
    }

    private void SpawnSpider()
    {
        animator.Play("SpiderSpawning");
    }
    private void HideSpider()
    {
        animator.Play("SpiderDespawning");
    }

}
