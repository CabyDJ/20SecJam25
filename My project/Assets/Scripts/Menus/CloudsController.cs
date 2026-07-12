using UnityEngine;

public class CloudsController : MonoBehaviour
{
    //[SerializeField]
    //private GameObject bigCloud;
    //[SerializeField]
    //private Animator bigAnimator;

    //[SerializeField]
    //private GameObject mediumCloud;
    [SerializeField]
    private Animator mediumAnimator;

    //[SerializeField]
    //private GameObject smallCloud;
    [SerializeField]
    private Animator smallAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //bigAnimator = bigCloud.AddComponent<Animator>();
        //mediumAnimator = mediumCloud.AddComponent<Animator>();
        //smallAnimator = smallCloud.AddComponent<Animator>();

        mediumAnimator.Play("MediumCloud");
        smallAnimator.Play("SmallCloud");
    }
}
