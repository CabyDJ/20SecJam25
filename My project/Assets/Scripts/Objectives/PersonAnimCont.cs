using System.Collections;
using UnityEngine;

public class PersonAnimCont : MonoBehaviour
{
    [SerializeField]
    GameObject fumesLeft;
    [SerializeField]
    GameObject fumesRight;

    private void ShowFumes()
    {
        fumesLeft.SetActive(true);
        StartCoroutine(LeftDelay());
    }

    private IEnumerator LeftDelay()
    {
        yield return new WaitForSeconds(0.3f);
        fumesRight.SetActive(true);
    }
}
