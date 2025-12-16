using System.Collections;
using UnityEngine;

public class TimeDestroy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float time = 0.5f;

    void Start()
    {
        StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
