using System.Collections;
using UnityEngine;

public class DiablasoController : MonoBehaviour
{
    private float speed = 4f;
    private Animator animatorMotion;
    [SerializeField]
    private Animator animatorSprite;

    private void Awake()
    {
        animatorMotion = GetComponent<Animator>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(-5.25f, transform.position.y), step);
    }

    public void StartMove1()
    {

    }

    public void StartMotion2()
    {
        animatorMotion.Play("DiablasoMotion2");
        animatorSprite.Play("DiablasoWalk");
    }

    public void StartGrantAnimation()
    {
        animatorSprite.Play("DiablasoGrant");
        //StartCoroutine(WaitFinishAnimations());
    }

    public void StartFireAnimation()
    {
        animatorSprite.Play("DiablasoFire");
    }

    private IEnumerator WaitFinishAnimations()
    {
        yield return new WaitForSeconds(4.5f);
        StartMotion2();
    }
}
