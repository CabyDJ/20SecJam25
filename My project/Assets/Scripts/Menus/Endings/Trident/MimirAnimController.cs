using UnityEngine;

public class MimirAnimController : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AlterAnim();
    }

    private void AlterAnim()
    {
        if (Random.Range(0, 2) == 1)
        {
            anim.Play("Mimir2Alter");
        }
    }
}
