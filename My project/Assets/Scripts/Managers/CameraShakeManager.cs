using Unity.Cinemachine;
using UnityEngine;

public class CameraShakeManager : MonoBehaviour
{
    public static CameraShakeManager instance;
    [SerializeField]
    private float globalShakeForce = 1.0f;

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }

    public void CameraShake(CinemachineImpulseSource impulseSource, Vector2 dir)
    {
        impulseSource.DefaultVelocity = dir;
        impulseSource.GenerateImpulseWithForce(globalShakeForce);
    }

}
