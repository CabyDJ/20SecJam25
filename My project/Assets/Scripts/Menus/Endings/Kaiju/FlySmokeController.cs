using UnityEngine;

public class FlySmokeController : MonoBehaviour
{
    bool dissipate;
    [SerializeField]
    private Animator smokeAnim;
    [SerializeField]
    private Animator silhouetteAnim;

    private void CheckDissipate()
    {
        if (dissipate)
        {
            smokeAnim.Play("SmokeDiss");
            silhouetteAnim.Play("SilhouetteDiss");
        }
    }

    public void SetDissipate()
    {
        dissipate = true;
    }
}
