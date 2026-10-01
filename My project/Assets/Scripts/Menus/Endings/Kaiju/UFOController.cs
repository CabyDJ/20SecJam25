using UnityEngine;

public class UFOController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float step = 2 * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.left, step);
    }

    private void StartMove()
    {

    }
}
