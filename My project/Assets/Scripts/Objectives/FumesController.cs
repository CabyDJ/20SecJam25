using UnityEngine;

public class FumesController : MonoBehaviour
{
    public bool stop;

    public void StopFuming()
    {
        stop = true;
    }

    private void CheckFuming()
    {
        if (stop)
        {
            gameObject.SetActive(false);
        }
    }

}
