using UnityEngine;

public class BeamSpriteController : MonoBehaviour
{
    [SerializeField]
    private BeamController beamCont;

    public void LaserEnd()
    {
        StartCoroutine(beamCont.StopBeam());
    }

}
