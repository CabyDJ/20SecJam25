using UnityEngine;

public class ExplosionsAnimCont : MonoBehaviour
{
    [SerializeField]
    BeamController beamCont;

    private void FinishExplosions()
    {
        beamCont.StopExplosion();
    }
}
