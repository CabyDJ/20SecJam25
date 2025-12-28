using UnityEngine;

public class DashController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private SpriteRenderer sprite;

    public void SetDash(Vector3 worldPos, Vector2 direction)
    {
        sprite.enabled = true;
        transform.SetPositionAndRotation(worldPos, Quaternion.FromToRotation(Vector3.down, direction));

        StartAnimation();
    }

    private void StartAnimation()
    {
        animator.Play("Dash", 0 , 0f);
    }
}
