using UnityEngine;
using UnityEngine.EventSystems;

public class FireBallController : MonoBehaviour
{
    float speed = 9f;
    [SerializeField]
    private GameObject target;

    private Vector3 direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);

        direction = (target.transform.position -  transform.position).normalized;
        //Debug.Log(direction);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<PitiController>())
        {
            collision.gameObject.GetComponent<PitiController>().Ignite();

            Destroy(this.gameObject);
        }
    }
}
