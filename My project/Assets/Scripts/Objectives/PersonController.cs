using UnityEngine;

public class PersonController : MonoBehaviour
{
    [SerializeField]
    DoorController doorCont;
    [SerializeField]
    FumesController fxLeftC;
    [SerializeField]
    FumesController fxRightC;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            //Debug.Log("+ SCORE");
            //GameManager.instance.ChangeScore(score);
            doorCont.CloseDoor();
            fxLeftC.StopFuming();
            fxRightC.StopFuming();
        }
    }
}
