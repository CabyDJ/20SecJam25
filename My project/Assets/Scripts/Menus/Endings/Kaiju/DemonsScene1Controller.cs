using System.Collections;
using UnityEngine;

public class DemonsScene1Controller : MonoBehaviour
{
    [SerializeField]
    GameObject demon1;
    [SerializeField]
    GameObject demon2;
    [SerializeField]
    GameObject demon3;

    private IEnumerator DemonsTimer()
    {
        StartDemon1();
        yield return new WaitForSeconds(1.25f);
        StartDemons();
    }

    public void CallDemons()
    {
        StartCoroutine(DemonsTimer());
    }

    private void StartDemon1()
    {
        demon1.SetActive(true);
    }

    private void StartDemons()
    {
        demon2.SetActive(true);
        demon3.SetActive(true);

    }
}
