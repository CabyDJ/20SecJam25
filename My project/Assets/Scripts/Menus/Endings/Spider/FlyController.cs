using System.Collections;
using UnityEngine;

public class FlyController : MonoBehaviour
{
    //[SerializeField]
    //private Animator spriteAnim;
    //[SerializeField]
    //private Animator PitiAnim;
    [SerializeField]
    private SpriteRenderer pitiSpr;
    //[SerializeField]
    //private Animator FireAnim;
    [SerializeField]
    private SpriteRenderer fireSpr;
    [SerializeField]
    private GameObject pitiPos;
    [SerializeField]
    private GameObject smoke;
    [SerializeField]
    private ParticleSystem fireParticles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GivePiti()
    {
        pitiSpr.enabled = true;
        smoke.SetActive(true);
        smoke.transform.parent = null;
        //StartCoroutine(GiveEndFrame());
    }

    //private IEnumerator GiveEndFrame()
    //{
    //    yield return new WaitForEndOfFrame();
    //    float t = spriteAnim.GetCurrentAnimatorStateInfo(0).normalizedTime;
    //    PitiAnim.Play("PitiUnlit", 0, t);
    //}

    public void LitPiti()
    {
        fireSpr.enabled = true;
        fireParticles.Play();
        //StartCoroutine(LitEndFrame());
    }

    //private IEnumerator LitEndFrame()
    //{
    //    yield return new WaitForEndOfFrame();
    //    float t = spriteAnim.GetCurrentAnimatorStateInfo(0).normalizedTime;
    //    FireAnim.Play("PitiFireOn", 0, t);

    //}
}
